using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _30July.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int? ReportsTo { get; set; }
    }
}