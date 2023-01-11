namespace DecisionSupport.DataAccess.Entities
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
