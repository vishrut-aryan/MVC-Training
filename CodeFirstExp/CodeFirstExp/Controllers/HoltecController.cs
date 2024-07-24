using CodeFirstExp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstExp.Controllers
{
    public class HoltecController : Controller
    {
        CustomerContext db = new CustomerContext();

        // GET: Holtec
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Emp_Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult AddCust()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCust(Customer c1)
        {
            db.Customers.Add(c1);
            db.SaveChanges();
            return View();
        }

        public ActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmp(Employee e1)
        {
            db.Employees.Add(e1);
            db.SaveChanges();
            return View();
        }
    }
}