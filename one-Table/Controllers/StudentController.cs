using one_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace one_Table.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        ContextClass db = new ContextClass();
        public ActionResult Index()
        {
            var emp12s = db.Students.Include(e => e.Branch);
            return View(emp12s.ToList());
        }

        public ActionResult Details(int? id)
        {
            
            Student emp12 = db.Students.Find(id);
            return View(emp12);
        }
        public ActionResult Create()
        {
            ViewBag.Dept12Id = new SelectList(db.Branches, "Id", "DName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EName,Salary,Dept12Id")] Student emp12)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(emp12);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dept12Id = new SelectList(db.Branches, "Id", "DName", emp12.BranchId);
            return View(emp12);
        }
        public ActionResult Edit(int? id)
        {
         
            Student emp12 = db.Students.Find(id);

            ViewBag.Dept12Id = new SelectList(db.Branches, "Id", "DName", emp12.BranchId);
            return View(emp12);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EName,Salary,Dept12Id")] Student emp12)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp12).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dept12Id = new SelectList(db.Branches, "Id", "DName", emp12.BranchId);
            return View(emp12);
        }
        public ActionResult Delete(int? id)
        {
            Student emp12 = db.Students.Find(id);
            if (emp12 == null)
            {
                return HttpNotFound();
            }
            return View(emp12);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student emp12 = db.Students.Find(id);
            db.Students.Remove(emp12);
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