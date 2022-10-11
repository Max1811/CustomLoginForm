using Microsoft.AspNetCore.Mvc;

namespace LoginForm.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        [HttpGet]
        public bool Get()
        {
            return false;
        }
    }
}
