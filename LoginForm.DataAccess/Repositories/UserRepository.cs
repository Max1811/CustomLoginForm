using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Abstract;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LoginForm.DataAccess.Repositories
{
    public class UserRepository : DataRepository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
            
        }

        public async Task<User> GetByLogin(string login)
        {
            return await Entities.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<bool> IsUserExists(string login)
        {
            return await Entities.AnyAsync(u => u.Login == login);
        }
    }
}
