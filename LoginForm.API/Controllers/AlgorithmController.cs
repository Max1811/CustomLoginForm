using LoginForm.BL.Parsing.Models;
using LoginForm.BL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LoginForm.API.Controllers
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
