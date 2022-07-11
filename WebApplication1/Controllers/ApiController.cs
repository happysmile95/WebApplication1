using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        protected void LogEnter(string method, object parameters = null)
        {
            _logger.LogTrace($"Enter in method {method} of controller {GetType().Name} with parameters {JsonConvert.SerializeObject(parameters)}");
        }

        protected void LogLeave(string method, object result = null)
        {
            _logger.LogTrace($"Leave method {method} of controller {GetType().Name} with result {JsonConvert.SerializeObject(result)}");
        }
    }
}
