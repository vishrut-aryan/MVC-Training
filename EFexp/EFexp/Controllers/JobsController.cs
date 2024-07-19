using EFexp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFexp.Controllers
{
    public class JobsController : Controller
    {
        EFexpEntities1 db = new EFexpEntities1();
        // GET: Jobs
        public ActionResult Index()
        {
            return View(db.USERDETAILS.ToList());
        }

        public ActionResult Create()
        {
            return View(db.USERDETAILS.ToList());
        }

        [HttpPost]
        public ActionResult Create(USERDETAIL u1)
        {
            db.USERDETAILS.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}