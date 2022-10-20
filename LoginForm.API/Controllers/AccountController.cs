using LoginForm.API.Models;
using LoginForm.BL.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using LoginForm.DataAccess.Entities;

namespace LoginForm.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserAware _currentUserAware;

        public AccountController(
            IUserService userService,
            ICurrentUserAware currentUserAware)
        {
            _userService = userService;
            _currentUserAware = currentUserAware;
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
        public async Task<bool> SignUp(SignUpModelDto credentials)
        {
            if (!ModelState.IsValid)
                return false;

            var user = await _userService.SignUp(credentials.Email, credentials.Login, credentials.Password);

            return true;
        }

        [HttpPost]
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
