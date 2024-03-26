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

        public string Info()
        {
            int id = 0;
            if (this.RouteData.Values["id"] != null)
                id = int.Parse(this.RouteData.Values["id"].ToString());

            return $"Request with id: {id}";
        }

        //[ActionName("Hello")]
        [NonAction]
        public string Test()
        {
            return "Test Action";
        }
    }
}
