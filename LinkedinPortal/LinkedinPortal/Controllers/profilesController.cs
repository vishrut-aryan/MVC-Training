using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinkedinPortal.Models;

namespace LinkedinPortal.Controllers
{
    public class profilesController : Controller
    {
        private linkedinEntities2 db = new linkedinEntities2();

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult UserEditProfile()
        {
            return View(); 
        }

        // GET: profiles
        public ActionResult Index()
        {
            var profiles = db.profiles.Include(p => p.user);
            return View(profiles.ToList());
        }

        // GET: profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: profiles/Create
        public ActionResult Create()
        {
            ViewBag.userid = new SelectList(db.users, "userid", "username");
            return View();
        }

        // POST: profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profileid,firstname,lastname,email,mobile,headline,summary,loc,education,experience,skills,userid")] profile profile)
        {
            if (ModelState.IsValid)
            {
                db.profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userid = new SelectList(db.users, "userid", "username", profile.userid);
            return View(profile);
        }

        // GET: profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = new SelectList(db.users, "userid", "username", profile.userid);
            return View(profile);
        }

        // POST: profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profileid,firstname,lastname,email,mobile,headline,summary,loc,education,experience,skills,userid")] profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userid = new SelectList(db.users, "userid", "username", profile.userid);
            return View(profile);
        }

        // GET: profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profile profile = db.profiles.Find(id);
            db.profiles.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
