using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ICompanyRepository : IGeneralRepository
    {
        Task<List<Company>> GetFullInfoAsync(Expression<Func<Company, bool>> expression);
    }
}
