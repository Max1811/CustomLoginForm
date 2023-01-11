using DecisionSupport.DataAccess.Entities;
using DecisionSupport.DataAccess.Repositories.Abstract;
using DecisionSupport.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DecisionSupport.DataAccess.Repositories
{
    public class VotingResultRepository : DataRepository<VotingResult>, IVotingResultRepository
    {
        public VotingResultRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public async Task<VotingResult> GetByUser(long userId, long votingId)
        {
            return await Entities.FirstOrDefaultAsync(u => u.UserId == userId && u.VotingId == votingId);
        }

        public async Task<IEnumerable<VotingResult>> GetByVoting(long votingId)
        {
            return await Entities.Where(u => u.VotingId == votingId).ToListAsync();
        }
    }
}
