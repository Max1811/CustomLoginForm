using LoginForm.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoginForm.DataAccess.Repositories.Abstract
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        void Add<T>(T entity)
            where T : class;

        void Remove<T>(T entity)
            where T : class;

        void RemoveRange<T>(IEnumerable<T> range)
            where T : BaseEntity;

        void Attach<T>(T entity)
            where T : BaseEntity;

        void AddRange<T>(IEnumerable<T> entities)
            where T : BaseEntity;

        IQueryable<T> GetQueryable<T>() where T : class;

        DbSet<T> GetDbSet<T>() where T : class;
    }
}
