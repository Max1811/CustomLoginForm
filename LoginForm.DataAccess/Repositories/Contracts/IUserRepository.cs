using LoginForm.DataAccess.Entities;

namespace LoginForm.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<User> Get(string login);
    }
}
