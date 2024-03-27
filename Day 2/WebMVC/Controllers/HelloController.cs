using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new HelloVM());
        }

        [HttpPost]
        public IActionResult SayHello(HelloVM m)
        {
            return View("Index", m);
        }
    }
}
