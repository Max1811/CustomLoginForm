namespace LoginForm.DataAccess.Entities
{
    public class VotingResult : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int VotingId { get; set; }
        public virtual Voting Voting { get; set; }

        public virtual ICollection<OrderedAlternative> Alternatives { get; set; } = new List<OrderedAlternative>();

        public bool IsVoted { get; set; } = false;
    }
}
