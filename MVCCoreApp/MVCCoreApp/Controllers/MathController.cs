using Microsoft.AspNetCore.Mvc;

namespace MVCCoreApp.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculator()
        {
            return View();
        }

        public IActionResult Add(string n1, string n2) 
        {
            int total = Convert.ToInt32(n1) + Convert.ToInt32(n2);
            ViewBag.Total = total;
            return View("Calculator");
        }

        public IActionResult Subtract(string n1, string n2)
        {
            int total = Convert.ToInt32(n1) - Convert.ToInt32(n2);
            ViewBag.Total = total;
            return View("Calculator");
        }

        public IActionResult Multiply(string n1, string n2)
        {
            int total = Convert.ToInt32(n1) * Convert.ToInt32(n2);
            ViewBag.Total = total;
            return View("Calculator");
        }

        public IActionResult Divide(string n1, string n2)
        {
            int total = Convert.ToInt32(n1) / Convert.ToInt32(n2);
            ViewBag.Total = total;
            return View("Calculator");
        }
    }
}
