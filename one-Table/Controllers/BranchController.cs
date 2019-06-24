using one_Table.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace one_Table.Controllers
{
    public class BranchController : Controller
    {
        ContextClass db = new ContextClass();
        public ActionResult Index()
        {
            return View(db.Branches.ToList());
        }
        public ActionResult Details(int? id)
        {
           Branch branch = db.Branches.Find(id);
            return View(branch);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        public ActionResult Edit(int? id)
        {
           
            Branch branch = db.Branches.Find(id);
            
            return View(branch);
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        public ActionResult Delete(int? id)
        {
            
          Branch dept12 = db.Branches.Find(id);
     
            return View(dept12);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           Branch dept12 = db.Branches.Find(id);
            db.Branches.Remove(dept12);
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