using DecisionSupport.BL.Models;
using DecisionSupport.DataAccess.Entities;
using System.Net;

namespace DecisionSupport.BL.Services.Contracts
{
    public interface IUserService
    {
        public Task<User?> ValidateUser(string login, string password);

        public Task<User> SignUp(SignUpModel model);
    }
}
