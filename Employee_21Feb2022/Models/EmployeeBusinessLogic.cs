using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_21Feb2022.Models
{
    public class EmployeeBusinessLogic
    {
        public Employee GetEmployee()
        {
            return new Employee()
            {
                Name = "MPS",
                Address = "Hyderabad",
                Gender = "Male",
                Salary = 10000M
            };
        }
    }
}