using EFCoreDBExp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDBExp.Controllers
{
    public class TestController : Controller
    {
        MvccoreContext db = new MvccoreContext();

        public IActionResult cityIndex()
        {
            return View(db.Cities.ToList());
        }
    }
}
