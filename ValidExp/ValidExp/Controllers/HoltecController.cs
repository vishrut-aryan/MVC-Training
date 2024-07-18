using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidExp.Models;

namespace ValidExp.Controllers
{
    public class HoltecController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345;");
        // GET: Holtec
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddEmp()
        {
            Employee e1 = new Employee();
            e1.dstlist = new List<Designation>();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM DESIGNATION", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Designation d1 = new Designation();
                d1.DesignationName = dr[1].ToString();
                e1.dstlist.Add(d1);
            }
            return View(e1);
        }

        [HttpPost]
        public ActionResult AddEmp(Employee e1, HttpPostedFileBase empPhoto)
        {
            empPhoto.SaveAs(Server.MapPath(@"~\Photo\") + empPhoto.FileName);

            int active = 0;
            if (e1.isActive == true)
                active = 1;

            conn.Open();

            string query = "INSERT INTO EMPLOYEE VALUES('" + Request["EmpName"] + "', '" + Request["Gender"] + "', '" + Request["DOB"] + "', '" + Request["Email"] + "', '" + Request["Salary"] + "', '" + Request["Designation"] + "', '" + active + "', '" + empPhoto.FileName + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            return Content("Data Saved Successfully");
        }
    }
}