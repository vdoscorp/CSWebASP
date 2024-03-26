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

        public IActionResult Search(string search)
        {
            return Json(Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
            || c.Description.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
