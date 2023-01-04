namespace LoginForm.DataAccess.Entities
{
    public class Alternative : BaseEntity
    {
        public Alternative(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public virtual Voting? Voting { get; set; }
    }
}
