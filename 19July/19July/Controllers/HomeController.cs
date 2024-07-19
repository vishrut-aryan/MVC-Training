using _19July.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _19July.Controllers
{
    public class HomeController : Controller
    {
        STUDENTSEntities1 db = new STUDENTSEntities1();

        public ActionResult Index()
        {
            return View(db.STUDETAILS.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(STUDETAIL s1)
        {
            s1.Grading();
            db.STUDETAILS.Add(s1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(STUDETAIL s1)
        {
            db.STUDETAILS.Remove(s1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(STUDETAIL s1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult List(STUDETAIL s1)
        {
            if (s1.STUNAME == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDETAIL s = db.STUDETAILS.Find(s1.STUNAME);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }
    }
}