using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVC_User_Login.Controllers
{
    public class HoltecController : Controller
    {
        SqlConnection scoon = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345;");

        // GET: Holtec
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult UserAdmin()
        {
            string query;
            if (Session["USERROLE"].ToString() == "ADMIN")
            {
                query = "SELECT * FROM USERDETAIL";
            }
            else
            {
                query = "SELECT * FROM USERDETAIL WHERE USERNAME='" + Session["USERNAME"].ToString() + "'";
            }
            SqlDataAdapter adap = new SqlDataAdapter(query, scoon);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            ViewBag.userdata = dt;
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string query = "SELECT * FROM USERDETAIL WHERE USERNAME='" + username + "' and PASSWORD='" + password + "'";
            SqlDataAdapter adap = new SqlDataAdapter(query, scoon);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["USERID"] = dt.Rows[0][0];
                Session["USERNAME"] = dt.Rows[0][1];
                Session["USERROLE"] = dt.Rows[0][6];
                return RedirectToAction("UserAdmin");
            }
            else
            {
                return JavaScript("<script>alert('Authentication Fail')</script>");
            }
        }

        [HttpPost]
        public ActionResult NewUser(string username, string password, string email, string mobile, string marks, string desg)
        {
            if (Session["USERROLE"].ToString() == "ADMIN")
            {
                int mob = Convert.ToInt32(mobile);
                scoon.Open();

                string query = "INSERT INTO USERDETAILS VALUES('" + username + "', '" + password + "', '" + email + "', '" + mob + "', '" + marks + "', '" + desg + "')";
                SqlCommand cmd = new SqlCommand(query, scoon);
                cmd.ExecuteNonQuery();

                scoon.Close();
                return View();
            }
            else
            {
                return View("Access Denied");
            }
        }
    }
}