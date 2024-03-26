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

        public EmptyResult Void()
        {
            return new EmptyResult();
        }

        public ContentResult ParamsObject(Models.Person p)
        {
            var c = new ContentResult();
            c.Content = $"<h2>Data from query name: {p.Name} age: {p.Age}<h2>";
            c.ContentType = "text/html";
            return c;
        }

        [ActionName("Json")]
        public IActionResult JsonAction(Models.Person p)
        {
            return this.Json(p);
        }

        public IActionResult Specialist()
        {
            return this.Redirect("http://www.specialist.ru/");
        }

        public IActionResult ToInfo()
        {
            return this.RedirectToAction("Info");
        }

        public IActionResult Secure()
        {
            return this.StatusCode(403);
        }

        public IActionResult GetFile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt");

            return PhysicalFile(path, "text/plain");
        }

        public string Params(string name, int age)
        {

            return $"Data from query name: {name} age: {age}";
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
