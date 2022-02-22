using Employee_Feb22_Session2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Feb22_Session2.Controllers
{
    public class AccountController : Controller
    {
        readonly BOSH_CRMTrainingEntities EmployeeContext = null;

        public AccountController()
        {
            EmployeeContext = new BOSH_CRMTrainingEntities();
        }

        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(tblSignUp signUp)
        {
            var AlreadyExists = EmployeeContext.tblSignUps.Where(x => x.UserName == signUp.UserName).SingleOrDefault();
            if(AlreadyExists == null)
            {
                EmployeeContext.tblSignUps.Add(signUp);
                EmployeeContext.SaveChanges();
                TempData["SignUpMessage"] = "Successfully Registered.";
            }
            else
            {
                TempData["SignUpMessage"] = "Username is already taken.";
            }
            return View();
        }
    }
}