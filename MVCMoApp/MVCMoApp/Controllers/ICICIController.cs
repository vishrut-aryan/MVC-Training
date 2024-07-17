using MVCMoApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
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

        public ActionResult Test()
        {
            ViewData["username"] = "Vishrut Aryan";
            ViewBag.emailid = "VAryan@holtecasia.com";
            TempData["mobile"] = "9168312517";
            return View();
        }

        public ActionResult EditUsers()
        {
            return View();
        }

        public ActionResult ShowUsers()
        {
            SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345;");
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM USERDETAILS", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            List<UserModel> lst = new List<UserModel>();
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                UserModel obj = new UserModel();
                obj.UserId = Convert.ToInt32(dt.Rows[i][0].ToString());
                obj.UserName = dt.Rows[i][1].ToString();
                obj.Password = dt.Rows[i][2].ToString();
                obj.Email = dt.Rows[i][3].ToString();
                obj.Mobile = dt.Rows[i][4].ToString();
                lst.Add(obj);
            }

            List<Customer> cst = new List<Customer>();
            Customer c1 = new Customer();
            c1.CustId = 1;
            c1.CustName = "Aryan";
            c1.CustEmail = "aryan@gmail.com";
            cst.Add(c1);

            ViewBag.Customer = cst;
            return View(lst);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult DeleteUser(int id)
        {
            SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345;");
            conn.Open();

            string query = "DELETE FROM USERDETAILS WHERE USERID = " + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            return RedirectToAction("ShowUsers", "ICICI");
        }

        public ActionResult EditUser()
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