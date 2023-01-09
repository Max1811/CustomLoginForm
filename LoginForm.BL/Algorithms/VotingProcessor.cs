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
            var result = new List<VotingExecutionResult>();

            var deBordResult = DeBordAlgoritgh(results.ToList());
            var pleuralResult = PleuralProcedure(results.ToList());
            var reversedPleuralResult = ReversedPleuralProcedure(results.ToList());

            result.Add(deBordResult);
            result.Add(pleuralResult);
            result.Add(reversedPleuralResult);
            result.Add(TwoStagePleuralProcedure(results.ToList()));

            return result;
        }

        private VotingExecutionResult DeBordAlgoritgh(List<VotingResult> results)
        {
            var result = new VotingExecutionResult();
            result.MethodName = "De Bord Algorithm";

            var alternatives = results.Select(result => result.Alternatives).ToList();
            var uniqueNames = alternatives.Select(alternative => alternative.DistinctBy(a => a.Name)).ToList()[0]
                .Select(a => a.Name).ToList();

            foreach (var name in uniqueNames)
            {
                var rank = results.Select(res => res.Alternatives.Where(a => a.Name == name).Sum(x => x.Order)).ToList().Sum();

                var votingExecution = new VotingExecution()
                {
                    Alternatives = new List<string>() { name },
                    Rank = rank
                };
                result.Result.Add(votingExecution);
            }

            result.Result = result.Result.OrderBy(x => x.Rank).ToList();

            return result;
        }

        private VotingExecutionResult PleuralProcedure(List<VotingResult> results)
        {
            var result = new VotingExecutionResult();
            result.MethodName = "Pleural Procedure";

            var alternatives = results.Select(result => result.Alternatives).ToList();
            var uniqueNames = alternatives.Select(alternative => alternative.DistinctBy(a => a.Name)).ToList()[0]
                .Select(a => a.Name).ToList();

            foreach (var name in uniqueNames)
            {
                var rank = results.Select(res => res.Alternatives.Where(a => a.Name == name && a.Order == 1)
                    .Count()).ToList().Sum();

                var votingExecution = new VotingExecution()
                {
                    Alternatives = new List<string>() { name },
                    Rank = rank
                };
                result.Result.Add(votingExecution);
            }

            result.Result = result.Result.OrderByDescending(x => x.Rank).ToList();

            return result;
        }

        private VotingExecutionResult ReversedPleuralProcedure(List<VotingResult> results)
        {
            var result = new VotingExecutionResult();
            result.MethodName = "Reversed Pleural Procedure";

            var alternatives = results.Select(result => result.Alternatives).ToList();
            var uniqueNames = alternatives.Select(alternative => alternative.DistinctBy(a => a.Name)).ToList()[0]
                .Select(a => a.Name).ToList();

            foreach (var name in uniqueNames)
            {
                var rank = results.Select(res => res.Alternatives.Where(a => a.Name == name && a.Order == res.Alternatives.Count)
                    .Count()).ToList().Sum();

                var votingExecution = new VotingExecution()
                {
                    Alternatives = new List<string>() { name },
                    Rank = rank
                };
                result.Result.Add(votingExecution);
            }

            result.Result = result.Result.OrderByDescending(x => x.Rank).ToList();

            return result;
        }

        private VotingExecutionResult TwoStagePleuralProcedure(List<VotingResult> results)
        {
            var result = new VotingExecutionResult();
            result.MethodName = "Two Stage Pleural Procedure";

            var alternatives = results.Select(result => result.Alternatives).ToList();
            var uniqueNames = alternatives.Select(alternative => alternative.DistinctBy(a => a.Name)).ToList()[0]
                .Select(a => a.Name).ToList();

            foreach (var name in uniqueNames)
            {
                var rank = results.Select(res => res.Alternatives.Where(a => a.Name == name && a.Order == 1)
                    .Count()).ToList().Sum();

                var votingExecution = new VotingExecution()
                {
                    Alternatives = new List<string>() { name },
                    Rank = rank
                };
                result.Result.Add(votingExecution);
            }

            result.Result = result.Result.OrderByDescending(x => x.Rank).ToList();

            if (result.Result[0].Rank > results.Count / 2)
            {
                return result;
            }

            var firstCandidate = result.Result[0].Alternatives[0];
            var secondCandidate = result.Result[1].Alternatives[0]; 

            var groupByUser = results.GroupBy(x => x.UserId).ToList();

            var firstCount = 0;
            var secondCount = 0;

            foreach (var vote in groupByUser)
            {
                var firstOrder = vote.ToList()[0].Alternatives.Where(x => x.Name == firstCandidate).Select(x => x.Order).ToList()[0];
                var secondOrder = vote.ToList()[0].Alternatives.Where(x => x.Name == secondCandidate).Select(x => x.Order).ToList()[0];

                if (firstOrder < secondOrder)
                {
                    firstCount++;
                }
                else
                {
                    secondCount++;
                }
            }

            var votingExecutionFirst = new VotingExecution()
            {
                Alternatives = new List<string>() { firstCandidate },
                Rank = firstCount
            };
            var votingExecutionSecond = new VotingExecution()
            {
                Alternatives = new List<string>() { secondCandidate },
                Rank = secondCount
            };

            result.Result.Clear();
            result.Result.Add(votingExecutionFirst);
            result.Result.Add(votingExecutionSecond);

            return result;
        }
    }
}
