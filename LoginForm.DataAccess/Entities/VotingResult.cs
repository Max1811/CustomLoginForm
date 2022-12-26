namespace LoginForm.DataAccess.Entities
{
    public class VotingResult : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int VotingId { get; set; }
        public virtual Voting Voting { get; set; }
    }
}
