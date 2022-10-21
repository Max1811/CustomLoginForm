namespace LoginForm.BL.Models
{
    public class SignUpModel
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public byte[] Salt { get; set; }
    }
}
