using DecisionSupport.BL.Parsing.Models;
using DecisionSupport.BL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DecisionSupport.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AlgorithmController
    {
        private readonly IAlgorithmService _algorithmService;
        public AlgorithmController(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }       

        [HttpGet("analitic-hierarchy")]
        public IEnumerable<AlgorithmExecutionResult> GetAnaliticHierarchyResults(string fileName)
        {
            var result = _algorithmService.GetResults(fileName);

            return result;
        }
    }
}
