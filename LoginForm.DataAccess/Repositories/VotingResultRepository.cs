using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Abstract;
using LoginForm.DataAccess.Repositories.Contracts;

namespace LoginForm.DataAccess.Repositories
{
    public class VotingResultRepository : DataRepository<VotingResult>, IVotingResultRepository
    {
        protected VotingResultRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
