using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public ActionResult Welcome(string name)
        {
            return Content($"Welcome to Holtec {name}!");
        }

        [HttpGet]
        public ActionResult AddUser() 
        {
            return View();
        }

        [HttpPost]
        //  Using Parameters
        /*public ActionResult AddUser(string name, string password, string email, string mob)
        {
            SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345;");
            conn.Open();

            string query = "INSERT INTO USERDETAILS VALUES('" + name + "', '" + password + "', '" + email + "', '" + mob + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            return View();
        }*/

        //  Using Form Collection
        /*public ActionResult AddUser(FormCollection frm)
        {
            SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345;");
            conn.Open();

            string query = "INSERT INTO USERDETAILS VALUES('" + frm["name"] + "', '" + frm["password"] + "', '" + frm["email"] + "', '" + frm["mob"] + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            return RedirectToAction("Welcome", "Holtec");
        }*/

        //  Using Request
        public ActionResult AddUser(string name)
        {
            SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345;");
            conn.Open();

            string query = "INSERT INTO USERDETAILS VALUES('" + Request["name"] + "', '" + Request["password"] + "', '" + Request["email"] + "', '" + Request["mob"] + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            return RedirectToAction("Welcome", "Holtec");
        }
    }
}