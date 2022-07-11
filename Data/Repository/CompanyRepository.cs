using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class CompanyRepository : GeneralRepository, ICompanyRepository
    {
        private readonly CoreContext _coreContext;
        public CompanyRepository(CoreContext coreContext)
            : base(coreContext)
        {
            _coreContext = coreContext;
        }

        public Task<List<Company>> GetFullInfoAsync(Expression<Func<Company, bool>> expression)
        {
            return _coreContext.Set<Company>()
                .Where(expression)
                .Include(e => e.Departments)
                .ThenInclude(e => e.Divisions)
                .ToListAsync();
        }
    }
}
