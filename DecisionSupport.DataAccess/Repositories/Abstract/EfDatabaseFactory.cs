using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSupport.DataAccess.Repositories.Abstract
{
    public class EfDatabaseFactory : IDatabaseFactory
    {
        private readonly IDataContext _efDataContext;

        public EfDatabaseFactory(DbContextOptions<DataContext> contextOptions)
        {
            var dataContext = new DataContext(contextOptions);
            _efDataContext = new EfDataContext(dataContext);
        }
        public IDataContext Get()
        {
            return _efDataContext;
        }

    }
}
