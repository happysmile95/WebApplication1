using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class DepartmentRepository : GeneralRepository, IDepartamentRepository
    {
        private readonly CoreContext _context;
        public DepartmentRepository(CoreContext coreContext)
            : base(coreContext)
        {
            _context = coreContext;
        }

        public async Task BulkAddAsync(IList<Departament> departments)
        {
            await _context.BulkInsertAsync(departments);
        }

        public async Task BulkDeleteAsync(IList<Departament> departments)
        {
            await _context.BulkDeleteAsync(departments);
        }

        public async Task BulkUpdaAsync(IList<Departament> departments)
        {
            await _context.BulkUpdateAsync(departments);
        }

        public Task<List<Departament>> GetAllDepartaments()
        {
            return _context.Set<Departament>()
                .Where(e => !e.IsDeleted)
                .Include(e => e.Divisions)
                .ToListAsync();
        }
    }
}
