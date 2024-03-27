using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class HelloController : Controller
    {
        private IHello helloSrv;
        public HelloController(IHello hello)
        {
            this.helloSrv = hello;
        }

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

        [HttpGet]
        public IActionResult IndexSrv()
        {
            var m = new HelloVMSrv();
            m.Hello = this.helloSrv.GetHelloString(m.UserName);

            return View(m);
        }

        [HttpPost]
        public IActionResult SayHelloSrv(HelloVMSrv m)
        {
            if (!this.ModelState.IsValid)
                ViewBag.MyErrorMessage = "Некорректные данные";

            m.Hello = this.helloSrv.GetHelloString(m.UserName);

            return View("IndexSrv", m);
        }
    }
}
