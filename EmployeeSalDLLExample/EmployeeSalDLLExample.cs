using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalDLLExample
{
    public class Employee
    {
        decimal Basic;
        decimal HRA;
        decimal PF;

        public decimal CalculateEmployeeSalary(decimal basic, decimal hra, decimal pf)
        {
            return (basic + hra - pf);
        }

    }
}
