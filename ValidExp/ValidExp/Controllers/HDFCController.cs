using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValidExp.Controllers
{
    public class HDFCController : Controller
    {
        // GET: HDFC
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
    }
}