using LoginForm.BL.Parsing.Models;

namespace LoginForm.BL.Services.Contracts
{
    public interface IAlgorithmService
    {
        List<AlgorithmExecutionResult> GetResults(string path);
    }
}
