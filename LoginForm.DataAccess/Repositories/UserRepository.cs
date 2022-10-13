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

        public async Task<User> Get(string login)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            return user;
        }
    }
}
