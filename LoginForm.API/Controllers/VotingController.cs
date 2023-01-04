using LoginForm.API.Models;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public async Task<IEnumerable<VotingDto>> GetAll()
        {
            var list = await _votingRepository.GetAll();

            var votingDto = list.Select(result => new VotingDto() { Id = result.Id, Name = result.Name });

            return votingDto;
        }

        [HttpGet("get/{id}")]
        public async Task<VotingDto> Get(long id)
        {
            var item = await _votingRepository.Get(id);
            var votingDto = new VotingDto() { 
                Id = item.Id,
                Name = item.Name,
                Alternatives = item.Alternatives.Select(a => new AlternativeDto() { Name = a.Name }).ToList() };

            return votingDto;
        }

        [HttpPost("add")]
        public async Task<bool> Add([FromBody] VotingDto form)
        {
            var voting = new Voting();

            voting.Name = form.Name;
            voting.Alternatives = form.Alternatives.Select(alternative => new Alternative(alternative.Name)).ToList();

            await _votingRepository.AddAsync(voting);

            return true;
        }

        [HttpPost("remove")]
        public async Task<bool> Remove([FromBody] long id)
        {
            await _votingRepository.Remove(id);
            await _votingRepository.SaveChangesAsync();

            return true;
        }
    }
}
