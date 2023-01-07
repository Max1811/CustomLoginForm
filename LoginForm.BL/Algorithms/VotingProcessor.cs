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
    }
}
