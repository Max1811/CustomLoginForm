using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Abstract;
using LoginForm.DataAccess.Repositories.Contracts;

namespace LoginForm.DataAccess.Repositories
{
    public class AlternativeRepository : DataRepository<Alternative>, IAlternativeRepository
    {
        public AlternativeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
