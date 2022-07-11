using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileSystemManager : IFileSystemManager
    {
        private readonly string _departamentFileName = "departamentSettings.json";
        public async Task<DepartamentFileInfo> GetDepartamentFileInfo()
        {
            var content = await System.IO.File.ReadAllTextAsync(_departamentFileName);
            return JsonConvert.DeserializeObject<DepartamentFileInfo>(content);
        }

        public async Task SaveDepartamentFileInfo(DepartamentFileInfo departmentFileInfo)
        {
            var content = JsonConvert.SerializeObject(departmentFileInfo);
            await System.IO.File.WriteAllTextAsync(_departamentFileName, content);
        }
    }
}
