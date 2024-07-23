using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstExp.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("CustomerContext")
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
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