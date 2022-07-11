using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DepartamentDto : BaseInfo
    {
        public List<DivisionDto> Divisions { get; set; }
        public long CompanyId { get; set; } = -1;
    }
}
