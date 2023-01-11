using DecisionSupport.BL.Parsing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSupport.BL.Services.Contracts
{
    public interface IVotingAlgorithmService
    {
        Task<IEnumerable<VotingExecutionResult>> GetResults(long votingId);
    }
}
