using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using LoginForm.Shared;

namespace LoginForm.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<User?> ValidateUser(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            return user is not null && user.HashedPassword == Encryptor.Encrypt(password, user.PasswordSalt) ? user : null;
        }
    }
}
