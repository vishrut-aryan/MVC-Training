using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authorise_Authenticate.Models;
using System.Web.Security;

namespace Authorise_Authenticate.Controllers
{
    

    [Authorize]
    public class AuthController : Controller
    {
        MVCAUTHEntities1 db = new MVCAUTHEntities1();

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public ActionResult Login(string tusername, string tpassword, string trember)
        {
            bool save_user = trember == "rember";
            int icount = db.USERS.Where(d => d.USERNAME == tusername && d.PASSWORD == tpassword).Count();
            if (icount > 0)
            {
                FormsAuthentication.SetAuthCookie(tusername, save_user);  // Saved as HttpContext.Current.User.Identity
                return RedirectToAction("Index", "EMPLOYEEs");
            }
            else
            {
                return Content("Username or Password is not valid");
            }
        }

        public ActionResult SignOut()
        {
            // Sign out from forms authentication
            FormsAuthentication.SignOut();

            // Optionally clear the session
            Session.Clear();
            Session.Abandon();

            // Redirect to login page or home page
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Test()
        {
            return View();
        }
    }
}