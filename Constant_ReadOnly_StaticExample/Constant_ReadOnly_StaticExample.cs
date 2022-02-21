using EmployeeSalDLLExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constant_ReadOnly_StaticExample
{
    //class Constant_ReadOnly_Static
    //{
    //    static int intStatic = 10;
    //    const int intConst = 20;
    //    readonly int intRdonly = 20;
    //    readonly int intRdonly2;
    //    public Constant_ReadOnly_Static()
    //    {
    //        intRdonly = 30;
    //        intRdonly2 = 40;
    //        Add();
    //        intRdonly = 60;
    //        intRdonly2 = 70;
    //    }

    //    static void Add()
    //    {
    //        Console.WriteLine(Constant_ReadOnly_Static.intConst);
    //    }
    //}

    class Constant_ReadOnly_StaticExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("Employee Salary Calculation");
            Console.WriteLine("*******************************");
            Employee emp = new Employee();
            Console.Write("Enter Basic Salary\t: ");
            decimal dcBasic = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter HRA\t\t: ");
            decimal dcHRA = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter PF\t\t: ");
            decimal dcPF = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("\nSalary of an Employee\t: {0}", emp.CalculateEmployeeSalary(dcBasic, dcHRA, dcPF));
            Console.WriteLine("**************************************");
            Console.ReadKey();
        }
    }
}
