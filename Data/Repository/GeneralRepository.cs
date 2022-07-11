using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly CoreContext _context;
        public GeneralRepository(CoreContext context)
        {
            _context = context;
        }
        public Task<List<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return _context.Set<TEntity>().Where(expression).ToListAsync();
        }
    }
}
