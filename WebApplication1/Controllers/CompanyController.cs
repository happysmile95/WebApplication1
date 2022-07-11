using Common;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyHandler _companyHandler;
        public CompanyController(ICompanyHandler companyHandler)
        {
            _companyHandler = companyHandler;
        }

        [HttpGet]
        [Route("api/company/getAllCompanies")]
        public Task<List<CompanyInfoDto>> GetCompaniesInfo()
        {
            return _companyHandler.GetCompanies();
        }
    }
}
