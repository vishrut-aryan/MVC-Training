using EFexp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EFexp.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection scoon = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = EFexp;User Id = sa;Password = 12345;");

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string query = "SELECT * FROM USERDETAILS WHERE USERNAME='" + username + "' and PASSWORD='" + password + "'";
            SqlDataAdapter adap = new SqlDataAdapter(query, scoon);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["USERID"] = dt.Rows[0][0];
                Session["USERNAME"] = dt.Rows[0][1];
                return JavaScript("<script>alert('Authentication Success')</script>");
            }
            else
            {
                return JavaScript("<script>alert('Authentication Fail')</script>");
            }
        }

        [HttpPost]
        public ActionResult Register(string username, string password, string email, string mobile, string marks, string desg)
        {
            int mob = Convert.ToInt32(mobile);
            scoon.Open();

            string query = "INSERT INTO USERDETAILS VALUES('" + username + "', '" + password + "', '" + email + "', '" + mob + "')";
            SqlCommand cmd = new SqlCommand(query, scoon);
            cmd.ExecuteNonQuery();

            scoon.Close();
            return View();
        }
    }

}