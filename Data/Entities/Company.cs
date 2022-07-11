using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    [Table("Companies")]
    public class Company : BaseEntity
    {
        public ICollection<Departament> Departments { get; set; }
    }
}
