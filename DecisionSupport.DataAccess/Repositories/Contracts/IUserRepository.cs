using DecisionSupport.DataAccess.Entities;

namespace DecisionSupport.DataAccess.Repositories.Contracts
{
    public interface IUserRepository : IDataRepository<User>
    {
        public Task<User> GetByLogin(string login);

        public Task<bool> IsUserExists(string login);
    }
}
