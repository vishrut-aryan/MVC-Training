using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _16July.Controllers
{
    public class HoltecController : Controller
    {
        public HoltecController() { }

        // GET: Holtec
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return Content("Welcome to Holtec");
        }
    }
}