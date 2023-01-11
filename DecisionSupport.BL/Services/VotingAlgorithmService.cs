using DecisionSupport.BL.Algorithms;
using DecisionSupport.BL.Parsing.Models;
using DecisionSupport.BL.Services.Contracts;
using DecisionSupport.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSupport.BL.Services
{
    public class VotingAlgorithmService : IVotingAlgorithmService
    {
        private readonly IVotingResultRepository _votingResultRepository;
        private readonly IVotingProcessor _votingProcessor;

        public VotingAlgorithmService(IVotingResultRepository votingResultRepository, IVotingProcessor votingProcessor)
        {
            _votingResultRepository = votingResultRepository;
            _votingProcessor = votingProcessor;
        }

        public async Task<IEnumerable<VotingExecutionResult>> GetResults(long votingId)
        {
            var votingResults = await _votingResultRepository.GetByVoting(votingId);
            var results = _votingProcessor.Handle(votingResults);

            return results;
        }
    }
}
