using Common;
using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services.Services
{
    public class ExportXmlService : IExportXmlService
    {
        public void Export(List<DepartamentDto> departaments)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement root = doc.CreateElement("DepartamentsCollection");

            doc.AppendChild(root);

            var departamentsEl = doc.CreateElement("Departaments");
            foreach (var item in departaments)
            {
                var departamanetElement = doc.CreateElement("Departament");
                var departamentNameElement = doc.CreateElement("Name");
                var departamentNameText = doc.CreateTextNode(item.Name);
                departamentNameElement.AppendChild(departamentNameText);
                departamanetElement.AppendChild(departamentNameElement);
                
                departamentsEl.AppendChild(departamanetElement);
            }

            root.AppendChild(departamentsEl);
            doc.Save("document.xml");
        }
    }
}
