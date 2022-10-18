using LoginForm.API.Models;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using LoginForm.API.Models.ViewModels;

namespace LoginForm.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(
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
        [AllowAnonymous]
        public async Task<bool> Login(LoginCredentials credentials)
        {
            var user = await _userService.ValidateUser(credentials.Login, credentials.Password);

            if (user != null)
            {
                var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Login)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                return true;
            }

            return false;
        }

        [HttpPost]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpPost]
        public IActionResult SignUp(PostUserViewModel credentials)
        {
            if (!ModelState.IsValid)
                return null;

            var hashedPassword = _userService.EncryptPassword(credentials.Password);

            throw new NotImplementedException();
        }
    }
}
