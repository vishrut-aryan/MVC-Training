using _30July.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _30July.Controllers
{
    public class AjaxExpController : Controller
    {
        

        // GET: AjaxExp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListUsers()
        {
            string connectionString =  "Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = EFexp;User Id = sa;Password = 12345;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM USERDETAILS", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                List<UserDetails> lst = new List<UserDetails>();
                foreach (DataRow row in dt.Rows)
                {
                    UserDetails obj = new UserDetails
                    {
                        USERID = Convert.ToInt32(row["USERID"]),
                        USERNAME = row["USERNAME"].ToString(),
                        PASSWORD = row["PASSWORD"].ToString(),
                        EMAIL = row["EMAIL"].ToString(),
                        MOBILE = row["MOBILE"].ToString()
                    };
                    lst.Add(obj);
                }
                return View(lst);
            }
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult AddUserPartial()
        {
            return View();
        }

        public JsonResult SaveUser(string UserName, string Password, string Email, string Mobile)
        {
            SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = EFexp;User Id = sa;Password = 12345;TrustServerCertificate=true");
            string query = "INSERT INTO USERDETAILS VALUES ('" + UserName + "', '" + Password + "', '" + Email + "', '" + Mobile + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return Json(true);
        }
    }
}