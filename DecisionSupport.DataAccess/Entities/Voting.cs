namespace DecisionSupport.DataAccess.Entities
{
    public class Voting : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Alternative> Alternatives { get; set; } = new List<Alternative>();
    }
}
