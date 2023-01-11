namespace DecisionSupport.DataAccess.Entities
{
    public class OrderedAlternative : BaseEntity
    {
        public string Name { get; set; }     
        public int Order { get; set; }
        public virtual VotingResult VotingResult { get; set; }
    }
}
