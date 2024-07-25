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
using System.Threading;

namespace Authorise_Authenticate.Controllers
{
    [Authorize, LogDetails]
    public class AuthController : Controller
    {
        private MVCAUTHEntities1 db = new MVCAUTHEntities1();

        // GET: Auth
        public ActionResult Index()
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["SQLCONN"].ToString();
            SqlConnection sconn = new SqlConnection(conn);
            string fpath = System.Configuration.ConfigurationManager.AppSettings[""].ToString();
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
        public ActionResult Success()
        {
            return Content("Success");
        }

        [AllowAnonymous,OutputCache(Duration = 100)]
        public ActionResult DisplayDate()
        {
            return Content(System.DateTime.Now.ToString());
            //return RedirectToAction("Success");
        }

        [AllowAnonymous]
        public ActionResult Add_User() { return View(); }

        [AllowAnonymous, HttpPost]
        public ActionResult Add_User(USER u1)
        {
            db.USERS.Add(u1);
            db.SaveChanges();
            return Content("User added successfully");
        }
    }
}