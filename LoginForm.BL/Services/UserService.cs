using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using System.Security.Cryptography;

namespace LoginForm.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string EncryptPassword(string password)
        {
            byte[] salt;
            RandomNumberGenerator.Fill(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public async Task<User?> ValidateUser(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            if (user != null && EncryptPassword(password) == user.HashedPassword)
            {
                return user;
            }

            return null;
        }
    }
}
