using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Hello")]
        public string Test()
        {
            return "Test Action";
        }
    }
}
