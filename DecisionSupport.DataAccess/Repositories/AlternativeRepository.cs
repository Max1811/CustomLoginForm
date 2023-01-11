using DecisionSupport.DataAccess.Entities;
using DecisionSupport.DataAccess.Repositories.Abstract;
using DecisionSupport.DataAccess.Repositories.Contracts;

namespace DecisionSupport.DataAccess.Repositories
{
    public class AlternativeRepository : DataRepository<Alternative>, IAlternativeRepository
    {
        public AlternativeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
