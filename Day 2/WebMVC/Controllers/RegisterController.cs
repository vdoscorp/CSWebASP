using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View(new Registration());
        }

        public IActionResult Save(Registration r)
        {
            return View("Index", r);
        }
    }
}
