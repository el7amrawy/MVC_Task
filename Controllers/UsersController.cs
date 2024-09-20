using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCTask.Models;

namespace MVCTask.Controllers
{
    public class UsersController : Controller
    {
        private readonly Day6MvcdbContext _db;
        public UsersController(Day6MvcdbContext db) => _db = db;
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user == null) {
                return BadRequest();
            }
            if (Exists(user.Username))
            {
                var u = _db.users.FirstOrDefault(u => u.Username == user.Username);
                if (user.Password == u.Password)
                {
                    Alert("Logged in",$"Welcome {user.Username}");
                    if (user.Remember)
                    {
                        var options = new CookieOptions();
                        options.Expires = DateTime.Now.AddDays(10);
                        Response.Cookies.Append("user",u.Username+"-"+u.UserId, options);
                        Response.Cookies.Append("name",u.Username, options);
                    }
                    else
                    {
                        Response.Cookies.Append("user", u.Username + "-" + u.UserId);
                        Response.Cookies.Append("name", u.Username);
                    }
                    return RedirectToAction("","");
                }
                else
                {
                    Alert("Login attempt", "Wrong password");
                    return RedirectToAction();
                }
            }
            else
            {
                Alert("Login attempt", $"User: {user.Username} not found");
                return View();
            }
        }
        [NonAction]
        private bool Exists(string username)=>_db.users.Any(u=>u.Username == username);
        [NonAction]
        private void  Alert(string Head,string Message)
        {
            TempData["Toast_Action"]=Head;
            TempData["Toast_Message"]=Message;
        }
    }
}
