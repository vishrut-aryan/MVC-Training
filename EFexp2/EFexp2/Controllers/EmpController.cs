using EFexp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFexp2.Controllers
{
    public class EmpController : Controller
    {
        STUDENTSEntities db = new STUDENTSEntities();

        public ActionResult Display()
        {
            var empdeptlist = from dept in db.departments join emp in db.employees on dept.deptid equals emp.deptid join desg in db.designations on emp.desgid equals desg.desgid
                select new empd
                {
                    empid = emp.empid,
                    empname = emp.empname,
                    gender = emp.gender,
                    deptname = dept.deptname,
                    degname = desg.degname
                };
            return View(empdeptlist);
        }

        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TryCatch()
        {
            db.employees.Count();
            employee e2 = db.employees.Find(1);
            db.employees.Where(x => x.gender == "Male");
            db.employees.Sum(a => a.empid);
            db.employees.Skip(2).Take(3).ToList();
            db.employees.OrderBy(a => a.empname).Skip(2).Take(3).ToList();
            db.employees.OrderByDescending(a => a.empname).Skip(2).Take(3).ToList();

            return View(); 
        }

        public ActionResult AddEmp()
        {
            ViewBag.DeptId = new SelectList(db.departments, "DeptId", "DeptName");
            ViewBag.DesgId = new SelectList(db.designations, "DesgId", "DesgName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmp(employee e1)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(e1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.departments, "DeptId", "DeptName", e1.deptid);
            ViewBag.DesgId = new SelectList(db.designations, "DesgId", "DesgName", e1.desgid);

            return View(e1);
        }
    }
}