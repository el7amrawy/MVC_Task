using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask.Controllers
{
    public class TestController:Controller
    {
        public IActionResult SetTempData()
        {
            TempData["Temp"] = "lmaoooooo";
            return Content("temp data set");
        }
        public IActionResult ReadTempData()
        {
            string Temp = TempData.Peek("Temp") as string;
            return Content( Temp );
        }
        public IActionResult SetCookies()
        {
            var cookieOption = new CookieOptions();
            cookieOption.Expires= DateTime.Now.AddDays(10);
            Response.Cookies.Append("App-Name","lmaooo",cookieOption);
            return Content("cookie added");
        }
        public IActionResult ReadCookies()
        {
            string x = Request.Cookies["App-Name"];
            //var cookieOption = new CookieOptions();
            //cookieOption.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Append("App-Name", "lmaooo", cookieOption);
            return Content(x);
        }
        public IActionResult DeleteCookies()
        {
            Response.Cookies.Delete("App-Name");
            return Content("");
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString(key : "Name" ,value: "Hamasa Masa");
            HttpContext.Session.SetInt32("Age", 20);
            return Content("session set");
        }
        public IActionResult GetSession() {
            return Content($"Name: {HttpContext.Session.GetString("Name")} | Age: {HttpContext.Session.GetInt32("Age")}");
        }
    }
}
