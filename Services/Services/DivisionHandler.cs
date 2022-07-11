using AutoMapper;
using Common;
using Data;
using Data.Repository;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DivisionHandler : IDivisionHandler
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IMapper _mapper;
        public DivisionHandler(IDivisionRepository divisionRepository, IMapper mapper)
        {
            _divisionRepository = divisionRepository;
            _mapper = mapper;
        }
        public async Task<List<DivisionDto>> GetDivisions()
        {
            var divisions = await _divisionRepository.GetAsync<Division>(e => e.IsDeleted);
            return _mapper.Map<List<DivisionDto>>(divisions);
        }
    }
}
