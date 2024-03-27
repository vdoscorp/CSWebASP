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
            if (!this.ModelState.IsValid)
                ViewBag.MyErrorMessage = "Некорректные данные";

            return View("Index", m);
        }

        [HttpGet]
        [Route("hi/{Username?}")]
        [Route("privet")] //privet?UserName=Sergey
        public IActionResult Hi(HelloVM m)
        {
            return View("Index", m);
        }
    }
}
