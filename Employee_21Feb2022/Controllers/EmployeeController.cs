using Employee_21Feb2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_21Feb2022.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult ViewDetails()
        {
            Employee emp = new Employee();
            emp.Name = "MPS";
            emp.Address = "Hyderabad";
            emp.Gender = "Male";
            emp.Salary = 20000;

            return View(emp);
        }
    }
}