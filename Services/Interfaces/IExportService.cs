using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IExportService
    {
        public Task<int> ExportDepartaments();
    }
}