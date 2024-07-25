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

        int total;
        [HttpPost]
        public IActionResult Calculator(string n1, string n2, string btn_input, IFormCollection frm)
        {
            string nn = frm["n1"].ToString();
            string nnn = Request.Query["n1"].ToString();

            if (btn_input == "Add") { total = Convert.ToInt32(n1) + Convert.ToInt32(n2); }
            else if (btn_input == "Subtract") { total = Convert.ToInt32(n1) - Convert.ToInt32(n2); }
            else if (btn_input == "Multiply") { total = Convert.ToInt32(n1) * Convert.ToInt32(n2); }
            else if (btn_input == "Divide") { total = Convert.ToInt32(n1) / Convert.ToInt32(n2); }
            ViewBag.total = total;
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
