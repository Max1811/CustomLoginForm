namespace LoginForm.BL.Services.Contracts
{
    public interface IUserService
    {
        public string EncryptPassword(string password);
    }
}
