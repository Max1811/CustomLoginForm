using LoginForm.API.Models;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LoginForm.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(
            IUserService userService)
        {
            _userService = userService;
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
