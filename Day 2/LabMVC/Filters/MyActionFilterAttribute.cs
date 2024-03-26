using Microsoft.AspNetCore.Mvc.Filters;

namespace LabMVC.Filters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("ActionExecuting");
            if (context.ActionArguments.Any())
            {
                Console.WriteLine("Params:");
                foreach (var arg in context.ActionArguments)
                {
                    Console.WriteLine($"{arg.Key} : {arg.Value}");
                }
            }
            var list = context.RouteData.Values.Where(kv => kv.Key != "action" && kv.Key != "controller").ToList();
            if (list.Any())
            {
                Console.WriteLine("RouteData:");
                foreach (var kv in context.RouteData.Values.Where(kv => kv.Key != "action" && kv.Key != "controller"))
                {
                    Console.WriteLine($"{kv.Key} : {kv.Value}");
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"ActionExecuted Result: {context.Result}");
        }
    }
}
