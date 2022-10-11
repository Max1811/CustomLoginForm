namespace LoginForm.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string HashedPassword { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }
    }
}
