using Microsoft.AspNetCore.Mvc;

namespace MVCTask.Controllers
{
    [Route("x/[action]")]
    public class AuthController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn(string name, string password)
        {
            return View();
        }
    }
}
