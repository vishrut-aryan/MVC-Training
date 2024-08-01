using Microsoft.AspNetCore.Mvc;

namespace WebAPIClient.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult ShowStates()
        {
            return View("_ShowStates");
        }

        public IActionResult AddState()
        {
            return View("_AddState");
        }

        public IActionResult UpdateState()
        {
            return View("_UpdateState");
        }

        public IActionResult UpdateAState()
        {
            return View("_UpdateAState");
        }

        public IActionResult MainView()
        {
            return View();
        }
    }
}
