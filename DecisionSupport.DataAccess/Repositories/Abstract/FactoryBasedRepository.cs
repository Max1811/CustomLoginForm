using Microsoft.EntityFrameworkCore;

namespace DecisionSupport.DataAccess.Repositories.Abstract
{
    public class FactoryBasedRepository<T> where T : class
    {
        private readonly IDatabaseFactory _databaseFactory;

        private IDataContext? _dataContext;

        public FactoryBasedRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public virtual IQueryable<T> Entities => DataContext.GetQueryable<T>();

        public virtual DbSet<T> DbSet => DataContext.GetDbSet<T>();

        protected IDataContext DataContext => _dataContext ??= _databaseFactory.Get();
    }
}
