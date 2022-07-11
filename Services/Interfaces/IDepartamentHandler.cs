using Common;
using Data;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface IDepartamentHandler : IExportService, IImportService
    {
        Task<int> AddDepartamentsAsync(List<DepartamentDto> departaments);
        Task<int> UpdateDepartamentsAsync();
        Task<int> DeleteDepartamentsAsync(string name);
    }
}
