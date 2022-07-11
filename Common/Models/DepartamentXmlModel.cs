using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Models
{
	[XmlRoot(ElementName = "Departament")]
	public class Departament
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "Departaments")]
	public class Departaments
	{

		[XmlElement(ElementName = "Departament")]
		public List<Departament> Departament { get; set; }
	}

	[XmlRoot(ElementName = "DepartamentsCollection")]
	public class DepartamentsCollection
	{

		[XmlElement(ElementName = "Departaments")]
		public Departaments Departaments { get; set; }
	}
}
