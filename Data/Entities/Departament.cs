using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    [Table("Departaments")]
    public class Departament : BaseEntity
    {
        public Company Company { get; set; }
        public long CompanyId { get; set; }

        public List<Division> Divisions { get; set; }
    }
}
