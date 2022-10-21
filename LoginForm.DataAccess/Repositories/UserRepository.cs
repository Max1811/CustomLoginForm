using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LoginForm.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        private DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> Add(User entity)
        {
            var user = await _dataContext.Users.AddAsync(entity);
            _dataContext.SaveChanges();

            return user.Entity;
        }

        public async Task<User> GetByLogin(string login)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            return user;
        }

        public async Task<bool> IsUserExists(string login)
        {
            return await _dataContext.Users.AnyAsync(u => u.Login == login);
        }

        public async Task Update(User user)
        {
            _dataContext.Attach(user);
            await _dataContext.SaveChangesAsync();
        }
    }
}
