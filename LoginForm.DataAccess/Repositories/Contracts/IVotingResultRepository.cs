using LoginForm.DataAccess.Entities;

namespace LoginForm.DataAccess.Repositories.Contracts
{
    public interface IVotingResultRepository : IDataRepository<VotingResult>
    {
        public Task<VotingResult> GetByUser(long userId, long votingId);
    }
}
