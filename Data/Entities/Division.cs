using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    [Table("Divisions")]
    public class Division : BaseEntity
    {
        public ICollection<Departament> Departaments { get; set; }
    }
}
