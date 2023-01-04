using LoginForm.DataAccess.Entities;

namespace LoginForm.API.Models
{
    public class VotingDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<AlternativeDto>? Alternatives { get; set; }
    }
}
