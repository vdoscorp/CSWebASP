using Microsoft.AspNetCore.Mvc;
using System.Text;

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

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Request with id: {id}");

            foreach (var header in HttpContext.Request.Headers)
                sb.AppendLine($"{header.Key} : {header.Value}");

            return sb.ToString();
        }

        //[ActionName("Hello")]
        [NonAction]
        public string Test()
        {
            return "Test Action";
        }
    }
}
