using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class CourseController : Controller
    {
        private IEnumerable<Course> _courses;

        public CourseController(ICourseData cd)
        {
            this._courses = cd.All;
        }

        public IActionResult Index()
        {
            return Json(_courses);
        }

        [Route("courses")]
        public IActionResult List()
        {
            ViewData["CoursesCount"] = _courses.Count();
            return View(_courses);
        }

        //[Route("coursesearch/{search}")]
        [Route("search/{search}")] // higher priority then MapControllerRoute
        public IActionResult Search(string search)
        {
            return View("List", _courses.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
            || c.Description.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        [Route("course/{id:int}")]
        public IActionResult Details(int id)
        {
            return Json(_courses.Where(c => id == c.Id).SingleOrDefault());
        }
    }
}
