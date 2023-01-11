using DecisionSupport.DataAccess.Entities;

namespace DecisionSupport.DataAccess.Repositories.Contracts
{
    public interface IVotingResultRepository : IDataRepository<VotingResult>
    {
        public Task<VotingResult> GetByUser(long userId, long votingId);
        public Task<IEnumerable<VotingResult>> GetByVoting(long votingId);
    }
}
