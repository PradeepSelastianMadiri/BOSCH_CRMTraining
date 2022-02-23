using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee_Feb22_Session2.Models;

namespace Employee_Feb22_Session2.Controllers
{
    public class EmployeeController : Controller
    {
        private BOSH_CRMTrainingEntities db = new BOSH_CRMTrainingEntities();

        // GET: Employee
        public ActionResult Index()
        {
            var tblEmployees = db.tblEmployees.Include(t => t.tblDepartment).Include(t => t.tblEmployeeType);
            return View(tblEmployees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DeptID", "DeptName");
            ViewBag.EmployeeTypeId = new SelectList(db.tblEmployeeTypes, "EmployeeTypeId", "EmployeeType");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,EmpName,Gender,DepartmentID,Age,PhoneNo,Address,BasicSalary,EmployeeTypeId,DOB,DOJ,Email,City,Country")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                bool IsValid = true;

                if (tblEmployee.DOB.Value.Date > DateTime.Now.Date)
                {
                    ModelState.AddModelError("DOB", "DOB cannot be future date.");
                    IsValid = false;
                }

                if (tblEmployee.DOJ.Value.Date > DateTime.Now.Date)
                {
                    ModelState.AddModelError("DOJ", "DOJ cannot be future date.");
                    IsValid = false;
                }

                int EligibleYears = DateTime.Now.Year - tblEmployee.DOB.Value.Year;
                if (EligibleYears < 20)
                {
                    ModelState.AddModelError("DOB", "Your age is less than 20.");
                    IsValid = false;
                }

                if (IsValid)
                {
                    db.tblEmployees.Add(tblEmployee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(tblEmployee);
                }
            }

            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DeptID", "DeptName", tblEmployee.DepartmentID);
            ViewBag.EmployeeTypeId = new SelectList(db.tblEmployeeTypes, "EmployeeTypeId", "EmployeeType", tblEmployee.EmployeeTypeId);
            return View(tblEmployee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DeptID", "DeptName", tblEmployee.DepartmentID);
            ViewBag.EmployeeTypeId = new SelectList(db.tblEmployeeTypes, "EmployeeTypeId", "EmployeeType", tblEmployee.EmployeeTypeId);
            return View(tblEmployee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,EmpName,Gender,DepartmentID,Age,PhoneNo,Address,BasicSalary,EmployeeTypeId,DOB,Email,City,Country")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DeptID", "DeptName", tblEmployee.DepartmentID);
            ViewBag.EmployeeTypeId = new SelectList(db.tblEmployeeTypes, "EmployeeTypeId", "EmployeeType", tblEmployee.EmployeeTypeId);
            return View(tblEmployee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblEmployee tblEmployee = db.tblEmployees.Find(id);
            db.tblEmployees.Remove(tblEmployee);
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
