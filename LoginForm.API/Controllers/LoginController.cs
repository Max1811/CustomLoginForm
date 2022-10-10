using Microsoft.AspNetCore.Mvc;

namespace LoginForm.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public bool Get()
        {
            return false;
        }
    }
}
