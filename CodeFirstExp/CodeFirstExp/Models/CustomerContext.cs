using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstExp.Models
{
    public class CustomerContext
    {
    }

    public class City 
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<Customer> lstcst { get; set; }
    }

    public class Customer 
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public int CityId { get; set; }
        public City Citys { get; set; }
    }
}