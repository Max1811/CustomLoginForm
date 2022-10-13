using LoginForm.API.Models;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LoginForm.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public LoginController(
            IUserService userService,
            IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public bool Get()
        {
            return false;
        }

        [HttpPost]
        public async Task<User?> Login(LoginCredentials credentials)
        {
            return await _userService.ValidateUser(credentials.Login, credentials.Password);
        }
    }
}
