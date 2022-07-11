using Common;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IExportXmlService
    {
        void Export(List<DepartamentDto> departaments);
    }
}