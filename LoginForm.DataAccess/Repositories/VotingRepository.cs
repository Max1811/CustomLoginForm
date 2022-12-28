using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Abstract;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LoginForm.DataAccess.Repositories
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
