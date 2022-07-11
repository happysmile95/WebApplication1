using AutoMapper;
using Common;
using Data;
using Data.Repository;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DepartmentHandler : IDepartamentHandler
    {
        private readonly IDepartamentRepository _departamentRepository;
        private readonly IDivisionRepository _divisionRepository;
        private readonly IFileSystemManager _fileSystemManager;
        private readonly IExportXmlService _exportService;
        private readonly IImportXmlService _importService;
        private readonly IMapper _mapper;

        private readonly ILogger<DepartmentHandler> _logger;
        public DepartmentHandler(IDepartamentRepository departamentRepository, IMapper mapper, IFileSystemManager fileSystemManager, IDivisionRepository divisionRepository,
            IExportXmlService exportService, IImportXmlService importService, ILogger<DepartmentHandler> logger)
        {
            _departamentRepository = departamentRepository;
            _mapper = mapper;
            _fileSystemManager = fileSystemManager;
            _divisionRepository = divisionRepository;
            _exportService = exportService;
            _importService = importService;
            _logger = logger;
        }
        public async Task<int> AddDepartamentsAsync(List<DepartamentDto> departments)
        {
            try
            {
                var departamentFileInfo = await _fileSystemManager.GetDepartamentFileInfo();
                var newDepartaments = new List<Departament>();

                foreach (var item in departments)
                {
                    var divisionsNames = item.Divisions.Select(e => e.Name).Distinct();
                    var divisions = await _divisionRepository.GetAsync<Division>(e => divisionsNames.Contains(e.Name) && !e.IsDeleted);

                    var newItem = _mapper.Map<Departament>(item);
                    newItem.Divisions.AddRange(divisions);

                    departamentFileInfo.DepartamentNumber++;
                    newItem.Name = string.Join(" ", newItem.Name, departamentFileInfo.DepartamentNumber);
                    newDepartaments.Add(newItem);
                }
                await _departamentRepository.BulkAddAsync(newDepartaments);
                await _fileSystemManager.SaveDepartamentFileInfo(departamentFileInfo);

                return ResponseStatusCodes.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(AddDepartamentsAsync)}. Error during process");
                return ResponseStatusCodes.Error;
            }
        }

        public async Task<int> DeleteDepartamentsAsync(string name)
        {
            try
            {
                var departments = await _departamentRepository.GetAsync<Departament>(e => e.Name == name && !e.IsDeleted);
                if (!departments.Any())
                    return ResponseStatusCodes.Empty;
                await _departamentRepository.BulkDeleteAsync(departments);
                return ResponseStatusCodes.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(DeleteDepartamentsAsync)}. Error during process");
                return ResponseStatusCodes.Error;
            }
        }

        public async Task<int> ExportDepartaments()
        {
            try
            {
                var departaments = await _departamentRepository.GetAsync<Departament>(e => !e.IsDeleted);
                var departamentsDtos = _mapper.Map<List<DepartamentDto>>(departaments);
                _exportService.Export(departamentsDtos);
                return ResponseStatusCodes.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(ExportDepartaments)}. Error during process");
                return ResponseStatusCodes.Error;
            }
        }

        public async Task<int> ImportDepartaments()
        {
            try
            {
                var files = Directory.GetFiles("departamentFolder");
                var departamentFileDto = await _fileSystemManager.GetDepartamentFileInfo();
                foreach (var file in files)
                {
                    var result = await _importService.GetDepartaments(file);

                    var entities = _mapper.Map<List<Departament>>(result);
                    foreach (var item in entities)
                    {
                        departamentFileDto.DepartamentNumber++;
                        item.Name = string.Join(" ", item.Name, departamentFileDto.DepartamentNumber);
                    }
                    await _departamentRepository.BulkAddAsync(entities);
                    await _fileSystemManager.SaveDepartamentFileInfo(departamentFileDto);
                }
                return ResponseStatusCodes.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(ImportDepartaments)}. Error during process");
                return ResponseStatusCodes.Error;
            }
        }

        public Task<int> UpdateDepartamentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
