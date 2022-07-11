using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IGeneralRepository
    {
        Task<List<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
    }
}
