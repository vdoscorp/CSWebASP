using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class MyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[ActionName("Hello")]
        [NonAction]
        public string Test()
        {
            return "Test Action";
        }
    }
}
