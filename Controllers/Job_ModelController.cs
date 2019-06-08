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
    public class Job_ModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Job_Model
        public ActionResult Index()
        {
            var job_Model = db.Job_Model.Include(j => j.Categories_Model);
            return View(job_Model.ToList());
        }

        // GET: Job_Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Model job_Model = db.Job_Model.Find(id);
            if (job_Model == null)
            {
                return HttpNotFound();
            }
            return View(job_Model);
        }

        // GET: Job_Model/Create
        public ActionResult Create()
        {
            ViewBag.Categories_ModelId = new SelectList(db.Categories_Model, "Id", "CategoryName");
            return View();
        }

        // POST: Job_Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobTitle,JobContent,JobImage,Categories_ModelId")] Job_Model job_Model)
        {
            if (ModelState.IsValid)
            {
                db.Job_Model.Add(job_Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories_ModelId = new SelectList(db.Categories_Model, "Id", "CategoryName", job_Model.Categories_ModelId);
            return View(job_Model);
        }

        // GET: Job_Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Model job_Model = db.Job_Model.Find(id);
            if (job_Model == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories_ModelId = new SelectList(db.Categories_Model, "Id", "CategoryName", job_Model.Categories_ModelId);
            return View(job_Model);
        }

        // POST: Job_Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobTitle,JobContent,JobImage,Categories_ModelId")] Job_Model job_Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job_Model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories_ModelId = new SelectList(db.Categories_Model, "Id", "CategoryName", job_Model.Categories_ModelId);
            return View(job_Model);
        }

        // GET: Job_Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job_Model job_Model = db.Job_Model.Find(id);
            if (job_Model == null)
            {
                return HttpNotFound();
            }
            return View(job_Model);
        }

        // POST: Job_Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job_Model job_Model = db.Job_Model.Find(id);
            db.Job_Model.Remove(job_Model);
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
