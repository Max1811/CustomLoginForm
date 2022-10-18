using LoginForm.DataAccess.Entities;

namespace LoginForm.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<User> GetByLogin(string login);
    }
}
