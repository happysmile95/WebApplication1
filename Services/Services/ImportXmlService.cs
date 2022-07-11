using Common;
using Common.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Services.Services
{
    public class ImportXmlService : IImportXmlService
    {
        public async Task<List<DepartamentDto>> GetDepartaments(string fileName)
        {
            XmlSerializer serializer = new(typeof(DepartamentsCollection));
            var content = await File.ReadAllTextAsync(fileName);
            using (StringReader reader = new(content))
            {
                var collection = (DepartamentsCollection)serializer.Deserialize(reader);
                var result = new List<DepartamentDto>();
                foreach (var item in collection.Departaments.Departament)
                {
                    var departamentDto = new DepartamentDto
                    {
                        Name = item.Name.Split(" ").FirstOrDefault(),
                    };
                    result.Add(departamentDto);
                }
                return result;
            }
        }
    }
}
