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
        string connectionString = "Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = EFexp;User Id = sa;Password = 12345;";

        // GET: AjaxExp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListUsers(int page = 1)
        {
            int pageSize = 7; // Number of records per page
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

                int totalRecords = lst.Count;
                var users = lst.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                return View(users);
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO USERDETAILS (USERNAME, PASSWORD, EMAIL, MOBILE) VALUES (@UserName, @Password, @Email, @Mobile)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return Json(true);
        }


        public PartialViewResult UserListPartial(int page = 1)
        {
            int pageSize = 7;

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

                int totalRecords = lst.Count;
                var users = lst.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                return PartialView("_UserTable", users);
            }
        }


    }
}