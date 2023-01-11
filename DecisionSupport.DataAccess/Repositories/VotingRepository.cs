using DecisionSupport.DataAccess.Entities;
using DecisionSupport.DataAccess.Repositories.Abstract;
using DecisionSupport.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DecisionSupport.DataAccess.Repositories
{
    public class VotingRepository : DataRepository<Voting>, IVotingRepository
    {
        public VotingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
        public async Task<IEnumerable<Voting>> GetAll()
        {
            return await Entities.ToListAsync();
        }
    }
}
