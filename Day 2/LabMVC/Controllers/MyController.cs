using LabMVC.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LabMVC.Controllers
{
    [MyActionFilter]
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Params(string name, int age)
        {
            return $"Data from query name: {name} age: {age}";
        }

        [ActionName("Json")]
        public IActionResult JsonAction(Models.Person p)
        {
            return this.Json(p);
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
    }
}
