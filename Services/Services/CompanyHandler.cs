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
    public class CompanyHandler : ICompanyHandler
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<List<CompanyInfoDto>> GetCompanies()
        {
            var companies = await _companyRepository.GetFullInfoAsync(e => !e.IsDeleted);

            return _mapper.Map<List<CompanyInfoDto>>(companies);
        }
    }
}
