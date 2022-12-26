using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Abstract;
using LoginForm.DataAccess.Repositories.Contracts;

namespace LoginForm.DataAccess.Repositories
{
    public class VotingRepository : DataRepository<Voting>, IVotingRepository
    {
        protected VotingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
