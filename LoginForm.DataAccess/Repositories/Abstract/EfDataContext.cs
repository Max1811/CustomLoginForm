using LoginForm.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.DataAccess.Repositories.Abstract
{
    public class EfDataContext : IDataContext
    {
        private readonly DataContext _dataContext;

        public EfDataContext(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public void Add<T>(T entity)
            where T : class
        {
            _dataContext.Set<T>().Add(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities)
            where T : BaseEntity
        {
            _dataContext.Set<T>().AddRange(entities);
        }

        public void Remove<T>(T entity)
            where T : class
        {
            _dataContext.Set<T>().Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> range)
            where T : BaseEntity
        {
            _dataContext.Set<T>().RemoveRange(range);
        }

        public void Attach<T>(T entity) where T : BaseEntity
        {
            _dataContext.Set<T>().Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return _dataContext.Set<T>();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        IQueryable<T> IDataContext.GetQueryable<T>()
        {
            return GetDbSet<T>().AsQueryable();
        }
    }
}
