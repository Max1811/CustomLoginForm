using LoginForm.DataAccess.Entities;

namespace LoginForm.DataAccess.Repositories.Contracts
{
    public interface IVotingRepository : IDataRepository<Voting>
    {
        public Task<IEnumerable<Voting>> GetAll();
    }
}
