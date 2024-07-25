using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MVCCoreApp.Controllers
{
    public class ICICIController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = MVCCore;User Id = sa;Password = 12345;TrustServerCertificate=true");
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        public ICICIController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration() 
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM CITY", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                SelectListItem s1 = new SelectListItem();
                s1.Value = dr[0].ToString();
                s1.Text = dr[1].ToString();
                lst.Add(s1);
            }
            ViewBag.cityList = new SelectList(lst, "Value", "Text");
            return View(); 
        }

        [HttpPost]
        public IActionResult Registration(IFormCollection frm, IFormFile fResume)
        {
            string Name = frm["tname"].ToString();
            string gen = frm["rgender"].ToString();
            string dob = frm["dtdob"].ToString();
            string city = frm["drpcity"].ToString();
            string query = "INSERT INTO USERDETAILS VALUES('" + Name + "', '" + gen + "', '" + dob + "', '" + city + "', '" + fResume.FileName + "')";

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            string path = Path.Combine(this.Environment.WebRootPath, "resumes");
            string fileName = fResume.FileName;
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create)) { fResume.CopyTo(stream); }
            return View();
        }
    }
}
