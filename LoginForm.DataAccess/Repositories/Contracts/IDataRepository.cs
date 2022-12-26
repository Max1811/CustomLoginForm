using LoginForm.DataAccess.Entities;
using System.Linq.Expressions;

namespace LoginForm.DataAccess.Repositories.Contracts
{
    public interface IDataRepository<T> where T : BaseEntity
    {
        Task Remove(long id);
        void Remove(T entity);
        Task<List<T>> ListAll();
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T entity);
        void Attach(T item);
        void AddRange(IEnumerable<T> item);
        Task SaveChangesAsync();
        Task<T> Get(long id);
        Task<List<T>> Get(IEnumerable<long> ids);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> Where(Expression<Func<T, bool>> predicate);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task<int> Count();
        Task RemoveSoft(long id);
    }
}
