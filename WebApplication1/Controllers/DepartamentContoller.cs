using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class DepartamentContoller : ApiController
    {
        private readonly IDepartamentHandler _handler;
        public DepartamentContoller(IDepartamentHandler departamentHandler, ILogger<DepartamentContoller> logger)
            : base(logger)
        {
            _handler = departamentHandler;
        }

        [HttpGet]
        [Route("api/departament/test")]
        public List<DepartamentDto> Get()
        {
            return new List<DepartamentDto>
            {
                new DepartamentDto
                {
                    CompanyId = 1,
                    Divisions = new List<DivisionDto>
                    {
                        new DivisionDto
                        {
                            Name = "Отдел 1",
                        }
                    },
                    Name = "Департамент"
                }
            };
        }


        [HttpPost]
        [Route("api/departament/remove")]
        public Task<int> Remove([FromQuery] string name)
        {
            return _handler.DeleteDepartamentsAsync(name);
        }

        [HttpPost]
        [Route("api/departament/add")]
        public Task<int> Add(List<DepartamentDto> departaments)
        {
            var result = _handler.AddDepartamentsAsync(departaments);
            return result;
        }

        [HttpPost]
        [Route("api/departament/export")]
        public Task<int> Export()
        {
            return _handler.ExportDepartaments();
        }

        [HttpPost]
        [Route("api/departament/import")]
        public Task<int> Import()
        {
            LogEnter(nameof(Import));
            var result = _handler.ImportDepartaments();
            LogLeave(nameof(Import));
            return result;
        }
    }
}
