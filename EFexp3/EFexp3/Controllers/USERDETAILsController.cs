using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFexp3.Models;

namespace EFexp3.Controllers
{
    public class USERDETAILsController : Controller
    {
        private STUDENTSEntities db = new STUDENTSEntities();

        // GET: USERDETAILs
        public ActionResult Index()
        {
            return View(db.USERDETAILS.ToList());
        }

        // GET: USERDETAILs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERDETAIL uSERDETAIL = db.USERDETAILS.Find(id);
            if (uSERDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(uSERDETAIL);
        }

        // GET: USERDETAILs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USERDETAILs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USERID,USERNAME,PASSWORD,EMAIL,MOBILE,DATEOFBIRTH")] USERDETAIL uSERDETAIL)
        {
            if (ModelState.IsValid)
            {
                db.SP_ADDUSER1(uSERDETAIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSERDETAIL);
        }

        // GET: USERDETAILs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERDETAIL uSERDETAIL = db.USERDETAILS.Find(id);
            if (uSERDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(uSERDETAIL);
        }

        // POST: USERDETAILs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USERID,USERNAME,PASSWORD,EMAIL,MOBILE,DATEOFBIRTH,Age")] USERDETAIL uSERDETAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERDETAIL).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSERDETAIL);
        }

        // GET: USERDETAILs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERDETAIL uSERDETAIL = db.USERDETAILS.Find(id);
            if (uSERDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(uSERDETAIL);
        }

        // POST: USERDETAILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USERDETAIL uSERDETAIL = db.USERDETAILS.Find(id);
            db.USERDETAILS.Remove(uSERDETAIL);
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
