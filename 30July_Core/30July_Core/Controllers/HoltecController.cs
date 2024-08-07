using _30July_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;

namespace _30July_Core.Controllers
{
    public class HoltecController() : Controller
    {
        string str = "Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = EFexp;User Id = sa;Password = 12345;TrustServerCertificate=true";

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = str;
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
                con.ConnectionString = str;
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
                con.ConnectionString = str;
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
                con.ConnectionString = str;
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
            return Json(GetEmployees().ToList(), System.Text.Json.JsonSerializerOptions.Default);
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
            return Json("Records deleted successfully.", System.Text.Json.JsonSerializerOptions.Default);
        }

        [HttpGet]
        public PartialViewResult EmployeeDetails()
        {
            return PartialView("_EmployeeDetails");
        }

        public JsonResult GetEmployeesPage(int pageNumber, int pageSize)
        {
            var employees = GetEmployees()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalEmployees = GetEmployees().Count();

            return Json(new { Employees = employees, TotalCount = totalEmployees }, System.Text.Json.JsonSerializerOptions.Default);
        }

    }
}
