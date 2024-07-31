using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiExp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoltecServicesController : ControllerBase
    {
        SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = EFexp;User Id = sa;Password = 12345;TrustServerCertificate=true");

        // GET: api/<HoltecController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // Pass country id, return states
        // GET api/<HoltecController>/5
        [HttpGet("{id}")]
        public IEnumerable<StateDetails> Get(int id)
        {
            List<StateDetails> lststates = new List<StateDetails>();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM STATE WHERE COUNTRY_ID=" + id, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                lststates.Add(new StateDetails
                {
                    StateID = (int)row["STATE_ID"],
                    StateName = row["STATE_NAME"].ToString(),
                    CountryID = (int)row["COUNTRY_ID"]
                });
            }
            return lststates;
        }

        // POST api/<HoltecController>
        [HttpPost]
        public void Post([FromBody] StateDetails state)
        {
            string query = "INSERT INTO STATE (STATE_NAME, COUNTRY_ID) VALUES (@StateName, @CountryID)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cmd.Parameters.AddWithValue("@CountryID", state.CountryID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // PUT api/<HoltecController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // Service to delete a country by countryID
        // DELETE api/<HoltecController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string query = "DELETE FROM STATE WHERE STATE_ID=" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
