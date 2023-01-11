using DecisionSupport.BL.Parsing.Models;

namespace DecisionSupport.BL.Services.Contracts
{
    public interface IAlgorithmService
    {
        List<AlgorithmExecutionResult> GetResults(string fileName);
    }
}
