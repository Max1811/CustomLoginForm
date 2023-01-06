using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Abstract;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LoginForm.DataAccess.Repositories
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
    }
}
