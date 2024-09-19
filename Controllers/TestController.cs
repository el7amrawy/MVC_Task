using Microsoft.AspNetCore.Mvc;

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
    }
}
