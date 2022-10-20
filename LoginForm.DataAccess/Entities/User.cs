namespace LoginForm.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string HashedPassword { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
