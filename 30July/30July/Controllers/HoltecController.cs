using _30July.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace _30July.Controllers
{
    public class HoltecController : Controller
    {
        string connectionString = "Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = EFexp;User Id = sa;Password = 12345;";

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT TOP 10 EmployeeID,LastName,FirstName,City,ReportsTo FROM Employees ORDER BY EmployeeID DESC";
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                Employee emp = new Employee()
                                {
                                    EmployeeID = Convert.ToInt32(sdr["EmployeeId"]),
                                    FirstName = sdr["FirstName"].ToString(),
                                    LastName = sdr["LastName"].ToString(),
                                    City = sdr["City"].ToString(),
                                    ReportsTo = Convert.ToInt32(sdr["ReportsTo"] == DBNull.Value ? null : sdr["ReportsTo"])
                                };
                                employees.Add(emp);
                            }
                        }
                    }
                    con.Close();
                }
            }
            return employees;
        }

        public void Add(Employee employee)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Employees(LastName,FirstName,City,ReportsTo) VALUES(@LastName,@FirstName,@City,@ReportsTo)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void Update(Employee employee)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE Employees SET LastName = @LastName,FirstName = @FirstName,City = @City WHERE EmployeeID = @EmployeeID";
                    cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                    cmd.Parameters.AddWithValue("@EmployeeID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployees()
        {
            return Json(GetEmployees().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEmployee(int id)
        {
            var employee = GetEmployees().FirstOrDefault(e => e.EmployeeID == id);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }
        public ActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddEmp(Employee emp)
        {
            try
            {
                Add(emp);
                return Json("Records added Successfully.");
            }
            catch
            {
                return Json("Records not added,");
            }
        }
        [HttpPost]
        public JsonResult AddEmployee(Employee emp)
        {
            try
            {
                Add(emp);
                return Json("Records added Successfully.");
            }
            catch
            {
                return Json("Records not added,");
            }
        }

        [HttpPost]
        public JsonResult DeleteEmployee(int id)
        {
            Delete(id);
            return Json("Records deleted successfully.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult EmployeeDetails()
        {
            return PartialView("_EmployeeDetails");
        }

        [HttpPost]
        public JsonResult UpdateEmployee(Employee emp)
        {
            try
            {
                Update(emp);
                return Json("Record updated successfully.");
            }
            catch (Exception ex)
            {
                return Json($"Unable to update record. Error: {ex.Message}");
            }
        }

    }
}