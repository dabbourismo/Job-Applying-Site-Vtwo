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
using System.IO;

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
        //1- Remove Bind (شيل البايند من البارامترت)
        //Bind(Include = "Id,JobTitle,JobContent,JobImage,Categories_ModelId")] 
        //note that the instance name of httppostedfilebase is the same name as the input helper inside the Create.cshtml view
        public ActionResult Create(Job_Model job_Model,HttpPostedFileBase uploadinput)
        {
            if (ModelState.IsValid)
            {
                //add this for image upload
                //using system.io
                //this path combines the serverpath (مجلد اسمه ابلودز على السيرفر) with the filename
                //(مجلد على السيرفر دي ) means create folder named uploads on root solution file
                string path = Path.Combine(Server.MapPath("~/Uploads"), uploadinput.FileName);
                uploadinput.SaveAs(path); //store the file on the server
                job_Model.JobImage = uploadinput.FileName; //store the file path on database (inside the propertie)
                //now to to the view ==> HTML.BeginForm();

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
