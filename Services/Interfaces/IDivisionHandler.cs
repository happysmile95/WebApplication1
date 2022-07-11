using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDivisionHandler
    {
        Task<List<DivisionDto>> GetDivisions();
    }
}
