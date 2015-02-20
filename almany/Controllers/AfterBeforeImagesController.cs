using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using almany;
using almany.Models;

namespace almany.Controllers
{
    public class AfterBeforeImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AfterBeforeImages
        public ActionResult Index()
        {
            return View(db.AfterBeforeImages.ToList());
        }

        // GET: AfterBeforeImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfterBeforeImage afterBeforeImage = db.AfterBeforeImages.Find(id);
            if (afterBeforeImage == null)
            {
                return HttpNotFound();
            }
            return View(afterBeforeImage);
        }

        // GET: AfterBeforeImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AfterBeforeImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,url_picture_before,url_picture_after,statuss,first_title,secoundry_title")] AfterBeforeImage afterBeforeImage)
        {
            if (ModelState.IsValid)
            {
                db.AfterBeforeImages.Add(afterBeforeImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(afterBeforeImage);
        }

        // GET: AfterBeforeImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfterBeforeImage afterBeforeImage = db.AfterBeforeImages.Find(id);
            if (afterBeforeImage == null)
            {
                return HttpNotFound();
            }
            return View(afterBeforeImage);
        }

        // POST: AfterBeforeImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,url_picture_before,url_picture_after,statuss,first_title,secoundry_title")] AfterBeforeImage afterBeforeImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afterBeforeImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(afterBeforeImage);
        }

        // GET: AfterBeforeImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AfterBeforeImage afterBeforeImage = db.AfterBeforeImages.Find(id);
            if (afterBeforeImage == null)
            {
                return HttpNotFound();
            }
            return View(afterBeforeImage);
        }

        // POST: AfterBeforeImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AfterBeforeImage afterBeforeImage = db.AfterBeforeImages.Find(id);
            db.AfterBeforeImages.Remove(afterBeforeImage);
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
