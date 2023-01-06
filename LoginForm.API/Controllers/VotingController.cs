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
        private readonly ICurrentUserAware _currentUserAware;
        private readonly IVotingRepository _votingRepository;
        private readonly IVotingResultRepository _votingResultRepository;
        public VotingController(
            IVotingRepository votingRepository,
            IVotingResultRepository votingResultRepository,
            ICurrentUserAware currentUserAware)
        {
            _votingRepository = votingRepository;
            _votingResultRepository = votingResultRepository;
            _currentUserAware = currentUserAware;
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

        [HttpGet("getResult/{votingId}")]
        public async Task<VotingResultDto> GetResult(long votingId)
        {
            var user = await _currentUserAware.GetCurrentUser();
            var result = await _votingResultRepository.GetByUser(user.Id, votingId);

            if (result != null)
            {
                var dto = new VotingResultDto();
                dto.Id = result.Id;
                dto.VotingId = result.VotingId;
                dto.Alternatives = result.Alternatives.Select(a => new OrderedAlternativeDto()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Order = a.Order
                }).OrderBy(x => x.Order).ToList();
                dto.IsVoted = result.IsVoted;

                return dto;
            }

            return null;
        }

        [HttpPost("makeVote")]
        public async Task<bool> MakeVote([FromBody] VotingResultDto votingResult)
        {
            var user = await _currentUserAware.GetCurrentUser();
            var result = await _votingResultRepository.GetByUser(user.Id, votingResult.VotingId ?? 0);

            if (result == null)
            {
                var voting = new VotingResult();
                voting.UserId = (await _currentUserAware.GetCurrentUser()).Id;
                voting.VotingId = votingResult.VotingId ?? 0;
                voting.Alternatives = votingResult.Alternatives.Select(a => new OrderedAlternative()        
                {    Id = a.Id,
                     Name = a.Name,
                     Order = a.Order ?? 1 
                }).ToList();
                voting.IsVoted = votingResult.IsVoted ?? true;

                await _votingResultRepository.AddAsync(voting);
            }
            else
            {
                foreach (var orderedAlternative in result.Alternatives)
                {
                    var item = votingResult.Alternatives.Where(v => v.Id == orderedAlternative.Id).FirstOrDefault();
                    orderedAlternative.Id = item.Id;
                    orderedAlternative.Name = item.Name;
                    orderedAlternative.Order = item.Order ?? 1;
                }

                await _votingResultRepository.UpdateAsync(result);
            }

            return true;
        }
    }
}
