using LoginForm.BL.Models;
using LoginForm.DataAccess.Entities;
using System.Net;

namespace LoginForm.BL.Services.Contracts
{
    public interface IUserService
    {
        public Task<User?> ValidateUser(string login, string password);

        public Task<User> SignUp(SignUpModel model);
    }
}
