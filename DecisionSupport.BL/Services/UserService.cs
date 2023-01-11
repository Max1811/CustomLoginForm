using AutoMapper;
using DecisionSupport.BL.Models;
using DecisionSupport.BL.Services.Contracts;
using DecisionSupport.DataAccess.Entities;
using DecisionSupport.DataAccess.Repositories.Contracts;
using DecisionSupport.Shared;

namespace DecisionSupport.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> SignUp(SignUpModel model)
        {
            byte[] passwordSalt;
            var hashedPassword = Encryptor.EncryptWithRandomSalt(model.Password, out passwordSalt);

            model.Salt = passwordSalt;

            var user = _mapper.Map<User>(model);

            user.PasswordSalt = passwordSalt;
            user.HashedPassword = hashedPassword;

            //add check for existing user by login
            return await _userRepository.AddAsync(user);
        }

        public async Task<User?> ValidateUser(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            return user is not null && user.HashedPassword == Encryptor.Encrypt(password, user.PasswordSalt) ? user : null;
        }
    }
}
