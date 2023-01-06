﻿using LoginForm.BL.Algorithms;
using LoginForm.BL.Parsing.Models;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.BL.Services
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

        public async Task<IEnumerable<VotingExecutionResult>> GetResults(int votingId)
        {
            var votingResults = await _votingResultRepository.GetByVoting(votingId);

            var results = _votingProcessor.Handle(votingResults);
            return results;
        }
    }
}
