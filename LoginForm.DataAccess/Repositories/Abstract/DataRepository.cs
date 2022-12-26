using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoginForm.DataAccess.Repositories.Abstract
{
    public class DataRepository<T> : FactoryBasedRepository<T>, IDataRepository<T>
        where T : BaseEntity
    {
        protected DataRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public virtual async Task<T> AddAsync(T entity)
        {
            DataContext.Add(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            DataContext.Attach(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            DataContext.AddRange(entities);
        }

        public virtual void Attach(T entity)
        {
            DataContext.Attach(entity);
        }

        public virtual async Task SaveChangesAsync()
        {
            await DataContext.SaveChangesAsync();
        }

        public virtual async Task<T> Get(long id)
        {
            return await Entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<T>> Get(IEnumerable<long> ids)
        {
            return await Entities.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<List<T>> ListAll()
        {
            return await Entities.ToListAsync();
        }

        public virtual async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await Entities.AnyAsync(predicate);
        }

        public virtual async Task Remove(long id)
        {
            Remove(await Get(id));
        }

        public virtual async Task RemoveSoft(long id)
        {
            var entity = await Get(id);
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;
        }

        public virtual void Remove(T entity)
        {
            DataContext.Remove(entity);
        }

        public virtual async Task<List<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await Entities.Where(expression).ToListAsync();
        }

        public async Task<int> Count() => await Entities.CountAsync();
    }
}
