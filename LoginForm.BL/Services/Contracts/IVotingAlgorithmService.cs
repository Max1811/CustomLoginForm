using LoginForm.BL.Parsing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Services.Contracts
{
    public interface IVotingAlgorithmService
    {
        Task<IEnumerable<VotingExecutionResult>> GetResults(int votingId);
    }
}
