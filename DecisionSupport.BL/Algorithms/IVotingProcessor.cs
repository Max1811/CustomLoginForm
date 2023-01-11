using DecisionSupport.BL.Parsing.Models;
using DecisionSupport.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSupport.BL.Algorithms
{
    public interface IVotingProcessor
    {
        List<VotingExecutionResult> Handle(IEnumerable<VotingResult> results);
    }
}
