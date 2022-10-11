using LoginForm.API.Models.ViewModels;
using LoginForm.BL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LoginForm.API.Controllers
{
    [ApiController]
    [Route("api/sign-up")]
    public class SignUpController : Controller
    {
        private readonly IUserService _userService;

        public SignUpController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Index(PostUserViewModel credentials)
        {
            if (!ModelState.IsValid)
                return null;

            var hashedPassword = _userService.EncryptPassword(credentials.Password);

            throw new NotImplementedException();
        }
    }
}
