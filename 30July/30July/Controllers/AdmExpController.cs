using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _30July.Controllers
{
    public class AdmExpController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = EFexp;User Id = sa;Password = 12345;TrustServerCertificate=true");

        public ActionResult Index()
        {
            List<SelectListItem> country = new List<SelectListItem>();
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM COUNTRY", conn);
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SelectListItem sItem = new SelectListItem();
                sItem.Value = dt.Rows[i]["COUNTRY_ID"].ToString();
                sItem.Text = dt.Rows[i]["COUNTRY_NAME"].ToString();
                country.Add(sItem);
            }
            ViewBag.COUNTRYNAME = new SelectList(country, "Value", "Text");

            return View();
        }

        public JsonResult StateList(string id)
        {
            List<SelectListItem> state = new List<SelectListItem>();
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM STATE WHERE COUNTRY_ID=" + id, conn);
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SelectListItem sItem = new SelectListItem();
                sItem.Value = dt.Rows[i]["STATE_ID"].ToString();
                sItem.Text = dt.Rows[i]["STATE_NAME"].ToString();
                state.Add(sItem);
            }
            return Json(state, JsonRequestBehavior.AllowGet);
        }
    }
}