using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IDepartamentRepository : IGeneralRepository
    {
        Task BulkAddAsync(IList<Departament> departments);
        Task BulkDeleteAsync(IList<Departament> departments);
        Task BulkUpdaAsync(IList<Departament> departments);
        Task<List<Departament>> GetAllDepartaments();
    }
}
