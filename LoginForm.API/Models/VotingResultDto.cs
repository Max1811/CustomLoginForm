namespace LoginForm.API.Models
{
    public class VotingResultDto
    {
        public int? Id { get; set; }

        public int? VotingId { get; set; }

        public List<OrderedAlternativeDto>? Alternatives { get; set; }

        public bool? IsVoted { get; set; }
    }
}
