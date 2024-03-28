using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebMVC.Filters;

namespace WebMVC.Controllers
{
    [MyActionFilter]
    public class MyController : Controller
    {
        private ILogger logger;

        public MyController(ILogger<MyController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                int a, b = 4, c = 0;
                a = b / c;
            }
            catch (DivideByZeroException ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }

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

        [TempData]
        public string ToInfoData {  get; set; }

        public IActionResult ToInfo()
        {
            //TempData["ToInfoData"] = "Data from ToInfo action";
            this.ToInfoData = "Data from ToInfo action"; 
            return this.RedirectToAction("Info");
        }

        public ViewResult Info()
        {
            ViewBag.ToInfoData = this.ToInfoData;
            ViewBag.InfoData = "Data from Info action";
            int id = 0;
            if (this.RouteData.Values["id"] != null)
                id = int.Parse(this.RouteData.Values["id"].ToString());

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Request with id: {id}");

            foreach (var header in HttpContext.Request.Headers)
                sb.AppendLine($"{header.Key} : {header.Value}");

            ViewBag.MainStr = sb.ToString();
            return View();
        }

        //[ActionName("Hello")]
        [NonAction]
        public string Test()
        {
            return "Test Action";
        }
    }
}
