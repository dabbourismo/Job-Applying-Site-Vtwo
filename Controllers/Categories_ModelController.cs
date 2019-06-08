using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityComponents.Models;
using JobApplicationSiteVtwo.Models;

namespace JobApplicationSiteVtwo.Controllers
{
    public class Categories_ModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories_Model
        public ActionResult Index()
        {
            return View(db.Categories_Model.ToList());
        }

        // GET: Categories_Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Model categories_Model = db.Categories_Model.Find(id);
            if (categories_Model == null)
            {
                return HttpNotFound();
            }
            return View(categories_Model);
        }

        // GET: Categories_Model/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories_Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,CategoryDescription")] Categories_Model categories_Model)
        {
            if (ModelState.IsValid)
            {
                db.Categories_Model.Add(categories_Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categories_Model);
        }

        // GET: Categories_Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Model categories_Model = db.Categories_Model.Find(id);
            if (categories_Model == null)
            {
                return HttpNotFound();
            }
            return View(categories_Model);
        }

        // POST: Categories_Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,CategoryDescription")] Categories_Model categories_Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categories_Model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories_Model);
        }

        // GET: Categories_Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Model categories_Model = db.Categories_Model.Find(id);
            if (categories_Model == null)
            {
                return HttpNotFound();
            }
            return View(categories_Model);
        }

        // POST: Categories_Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories_Model categories_Model = db.Categories_Model.Find(id);
            db.Categories_Model.Remove(categories_Model);
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
