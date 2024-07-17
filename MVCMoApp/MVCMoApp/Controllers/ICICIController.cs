using MVCMoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMoApp.Controllers
{
    public class ICICIController : Controller
    {
        // GET: ICICI
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult Linkedin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserModel u1)
        {
            u1.SaveUser();
            return RedirectToAction("Linkedin", "ICICI");
        }
    }
}