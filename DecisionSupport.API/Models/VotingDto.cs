using DecisionSupport.DataAccess.Entities;

namespace DecisionSupport.API.Models
{
    public class VotingDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<AlternativeDto>? Alternatives { get; set; }
    }
}
