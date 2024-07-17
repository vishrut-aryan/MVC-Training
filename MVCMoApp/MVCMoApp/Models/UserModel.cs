using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCMoApp.Models
{
    public class Customer 
    {
        public int CustId { get; set; }

        public string CustName { get; set; }

        public string CustEmail { get; set; }
    }

    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is Required")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Email is Required")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile Number is Required")]

        public string Mobile { get; set; }

        public void SaveUser() 
        {
            SqlConnection conn = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345;");
            conn.Open();

            string query = "INSERT INTO USERDETAILS VALUES('" + UserName + "', '" + Password + "', '" + Email + "', '" + Mobile + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}