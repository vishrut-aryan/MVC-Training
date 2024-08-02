using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPIClient.Models;

namespace WebAPIClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page1()
        {
            ViewBag.name = "index";
            ViewData["email"] = "a@g.c";
            TempData["mobile"] = "8976546782";
            return View();
        }

        public IActionResult Page2()
        {
            return View();
        }

        public IActionResult Page3()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ShowData()
        {
            Emp e1 = new Emp();
            e1.EmpId = 1;
            e1.EmpName = "samir";
            Student s1 = new Student();
            s1.RollNo = 401;
            s1.StudName = "kapil";
            ViewBag.s1 = s1;
            return View(e1);
        }
    }
}
