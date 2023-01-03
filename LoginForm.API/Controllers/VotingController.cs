using LoginForm.API.Models;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LoginForm.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class VotingController : Controller
    {
        private readonly IVotingRepository _votingRepository;
        public VotingController(IVotingRepository votingRepository)
        {
            _votingRepository = votingRepository;
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<Voting>> GetAll()
        {
            var result = await _votingRepository.GetAll();

            return result;
        }

        [HttpPost("add")]
        public async Task<bool> Add([FromBody] VotingAddForm form)
        {
            var voting = new Voting();

            voting.Name = form.Name;
            voting.Alternatives = form.Alternatives.Select(name => new Alternative(name)).ToList();

            await _votingRepository.AddAsync(voting);

            return true;
        }
    }
}
