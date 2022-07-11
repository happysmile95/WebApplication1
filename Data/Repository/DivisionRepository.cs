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
    public class DivisionRepository : GeneralRepository, IDivisionRepository
    {
        public DivisionRepository(CoreContext coreContext)
            : base(coreContext)
        { }
    }
}
