using LoginForm.API.Models;
using LoginForm.BL.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using LoginForm.DataAccess.Entities;
using AutoMapper;
using LoginForm.BL.Models;
using LoginForm.DataAccess.Repositories.Contracts;
using LoginForm.BL.Parsing;
using System.IO;

namespace LoginForm.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserAware _currentUserAware;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IUserRepository userRepository,
            ICurrentUserAware currentUserAware,
            IMapper mapper)
        {
            _userService = userService;
            _userRepository = userRepository;
            _currentUserAware = currentUserAware;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<bool> Login(LoginCredentials credentials)
        {
            var user = await _userService.ValidateUser(credentials.Login, credentials.Password);

            if (user != null)
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Name, user.Login)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                return true;
            }

            return false;
        }

        [HttpPost("sign-up")]
        public async Task<bool> SignUp(SignUpDto credentials)
        {
            if (!ModelState.IsValid)
                return false;

            bool isUserExists = await _userRepository.IsUserExists(credentials.Login);

            if (isUserExists) // add message that this login has been already taken
                return false;

            var userModel = _mapper.Map<SignUpModel>(credentials);

            var user = await _userService.SignUp(userModel);

            return true;
        }

        [HttpPost("logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpGet("me")]
        public async Task<CurrentUserDto?> Me()
        {         
            User? currentUser = await _currentUserAware.GetCurrentUser();

            return currentUser == null ? null : 
                await Task.FromResult(new CurrentUserDto
                {
                    Id = currentUser.Id,
                    Login = currentUser.Login
                });
        }
    }
}
