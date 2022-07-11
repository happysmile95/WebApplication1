using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class CompanyInfoDto : BaseInfo
    {
        public List<DepartamentDto> Departaments { get; set; }
    }
}
