using DecisionSupport.DataAccess.Entities;

namespace DecisionSupport.DataAccess.Repositories.Contracts
{
    public interface IVotingRepository : IDataRepository<Voting>
    {
        public Task<IEnumerable<Voting>> GetAll();
    }
}
