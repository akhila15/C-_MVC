using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ajax_MVC.Models;

namespace Ajax_MVC.Controllers
{
    public class Department_2Controller : Controller
    {
        private Dept_Emp_2Context db = new Dept_Emp_2Context();

        // GET: Department_2
        public ActionResult Index()
        {
            return View(db.Department_2s.ToList());
        }
        public ActionResult ShowEmp(int id)
        {
            var emp = from n in db.Employee_2s where n.Department_2Id == id select n;
            return PartialView(emp);
        }
        // GET: Department_2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_2 department_2 = db.Department_2s.Find(id);
            if (department_2 == null)
            {
                return HttpNotFound();
            }
            return View(department_2);
        }

        // GET: Department_2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department_2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DName,Location")] Department_2 department_2)
        {
            if (ModelState.IsValid)
            {
                db.Department_2s.Add(department_2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department_2);
        }

        // GET: Department_2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_2 department_2 = db.Department_2s.Find(id);
            if (department_2 == null)
            {
                return HttpNotFound();
            }
            return View(department_2);
        }

        // POST: Department_2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DName,Location")] Department_2 department_2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department_2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department_2);
        }

        // GET: Department_2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_2 department_2 = db.Department_2s.Find(id);
            if (department_2 == null)
            {
                return HttpNotFound();
            }
            return View(department_2);
        }

        // POST: Department_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department_2 department_2 = db.Department_2s.Find(id);
            db.Department_2s.Remove(department_2);
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
