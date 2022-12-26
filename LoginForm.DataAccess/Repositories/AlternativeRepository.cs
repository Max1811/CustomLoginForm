using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Abstract;
using LoginForm.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.DataAccess.Repositories
{
    public class AlternativeRepository : DataRepository<Alternative>, IAlternativeRepository
    {
        protected AlternativeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
