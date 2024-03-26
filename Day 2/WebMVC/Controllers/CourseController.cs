using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return Json(Course.All);
        }
    }
}
