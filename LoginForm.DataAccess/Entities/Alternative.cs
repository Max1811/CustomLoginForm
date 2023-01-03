namespace LoginForm.DataAccess.Entities
{
    public class Alternative : BaseEntity
    {
        public string Name { get; set; }

        public virtual Voting Voting { get; set; }
    }
}
