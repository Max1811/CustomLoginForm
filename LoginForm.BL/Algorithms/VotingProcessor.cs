using LoginForm.BL.Parsing.Models;
using LoginForm.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Algorithms
{
    public class VotingProcessor : IVotingProcessor
    {
        public List<VotingExecutionResult> Handle(IEnumerable<VotingResult> results)
        {
            throw new NotImplementedException();
        }
    }
}
