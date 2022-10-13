using LoginForm.DataAccess.Entities;

namespace LoginForm.BL.Services.Contracts
{
    public interface IUserService
    {
        public string EncryptPassword(string password);

        public Task<User?> ValidateUser(string login, string password);
    }
}
