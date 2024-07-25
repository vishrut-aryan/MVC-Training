using Microsoft.AspNetCore.Mvc;
using MVCCoreApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using static System.Formats.Asn1.AsnWriter;
using System.Data;

namespace MVCCoreApp.Controllers
{
    public class HoltecController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = MVCCore;User Id = sa;Password = 12345;TrustServerCertificate=true");

        public IActionResult Index()
        {
            List<Customer> lst = new List<Customer>();
            string query = "SELECT * FROM CUSTOMER";
            using (conn)
            {
                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Customer customer = new Customer();
                        customer.CUSTID = Convert.ToInt32(row["CUSTID"]);
                        customer.CUSTNAME = row["CUSTNAME"].ToString();
                        customer.CUSTEMAIL = row["CUSTEMAIL"].ToString();
                        customer.CUSTMOBILE = row["CUSTMOBILE"].ToString();
                        lst.Add(customer);
                    }
                }
            }
            return View(lst);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(Customer c1)
        {
            string query = "INSERT INTO CUSTOMER VALUES('" + c1.CUSTNAME + "', '" + c1.CUSTEMAIL + "', '" + c1.CUSTMOBILE + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int ID, string NAME)
        {
            string query = "DELETE FROM CUSTOMER WHERE(CUSTID='" + ID + "' AND CUSTNAME='" + NAME + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }
    }
}
