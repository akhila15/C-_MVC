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
    public class Employee_2Controller : Controller
    {
        private Dept_Emp_2Context db = new Dept_Emp_2Context();

        // GET: Employee_2
        public ActionResult Index()
        {
            var employee_2s = db.Employee_2s.Include(e => e.Department_2);
            return View(employee_2s.ToList());
        }

        // GET: Employee_2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_2 employee_2 = db.Employee_2s.Find(id);
            if (employee_2 == null)
            {
                return HttpNotFound();
            }
            return View(employee_2);
        }

        // GET: Employee_2/Create
        public ActionResult Create()
        {
            ViewBag.Department_2Id = new SelectList(db.Department_2s, "Id", "DName");
            return View();
        }

        // POST: Employee_2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EName,Salary,Department_2Id")] Employee_2 employee_2)
        {
            if (ModelState.IsValid)
            {
                db.Employee_2s.Add(employee_2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department_2Id = new SelectList(db.Department_2s, "Id", "DName", employee_2.Department_2Id);
            return View(employee_2);
        }

        // GET: Employee_2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_2 employee_2 = db.Employee_2s.Find(id);
            if (employee_2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Department_2Id = new SelectList(db.Department_2s, "Id", "DName", employee_2.Department_2Id);
            return View(employee_2);
        }

        // POST: Employee_2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EName,Salary,Department_2Id")] Employee_2 employee_2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department_2Id = new SelectList(db.Department_2s, "Id", "DName", employee_2.Department_2Id);
            return View(employee_2);
        }

        // GET: Employee_2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_2 employee_2 = db.Employee_2s.Find(id);
            if (employee_2 == null)
            {
                return HttpNotFound();
            }
            return View(employee_2);
        }

        // POST: Employee_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_2 employee_2 = db.Employee_2s.Find(id);
            db.Employee_2s.Remove(employee_2);
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
