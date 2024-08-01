using ApiExp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
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
        [HttpGet("GetStates")]
        public IEnumerable<StateDetails> Get()
        {
            List<StateDetails> lststates = new List<StateDetails>();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM STATE", conn);
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

        // Pass country id, return states
        // GET api/<HoltecController>/5
        [HttpGet("GetStatePerCountry/{id}")]
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
        [HttpPost("AddState")]
        public string Post([FromBody] StateDetails state)
        {
            string str = "The state was added successfully";
            int icount = 0;
            string query = "INSERT INTO STATE (STATE_NAME, COUNTRY_ID) VALUES (@StateName, @CountryID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StateName", state.StateName);
            cmd.Parameters.AddWithValue("@CountryID", state.CountryID);
            conn.Open();

            SqlCommand duplicheck = new SqlCommand("select count(*) from STATE where STATE_NAME='" + state.StateName + "'", conn);
            icount = Convert.ToInt32(duplicheck.ExecuteScalar().ToString());
            if (icount == 0)
                cmd.ExecuteNonQuery();
            else
                str = "This state already exists";

            conn.Close();
            return str;
        }

        // PUT api/<HoltecController>/5
        [HttpPut("UpdateState/{id}")]
        public string Put(int id, [FromBody] StateDetails state)
        {
            string query = "UPDATE STATE SET STATE_NAME = @StateName, COUNTRY_ID = @CountryID WHERE STATE_ID = @StateID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StateName", state.StateName);
            cmd.Parameters.AddWithValue("@CountryID", state.CountryID);
            cmd.Parameters.AddWithValue("@StateID", state.StateID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return "The state was updated successfully";
        }

        // Service to delete a country by countryID
        // DELETE api/<HoltecController>/5
        [HttpDelete("DeleteState/{id}")]
        public string Delete(int id)
        {
            string query = "DELETE FROM STATE WHERE STATE_ID=" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return "The state was deleted successfully";
        }
    }
}
