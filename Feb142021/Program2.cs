using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    interface Bank1
    {
        void GetBranchinfo();
        void displayinfo();
    }
    interface emp1
    {
        void Empdata();
    }
    class A : Bank1, emp1
    {
        string branchcode, branchname, branchaddress;
        int n;
        int empid;
        string empname;
        public void Empdata()
        {
            Console.WriteLine("Enter Employee Details");
            Console.Write("Enter Employee ID : ");
            empid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name : ");
            empname = Console.ReadLine();
        }
        public void GetBranchinfo()
        {
            Console.WriteLine("\n\nEnter Branch Details");
            Console.Write("Enter Branch Name : ");
            branchname = Console.ReadLine();
            Console.Write("Enter Branch Address : ");
            branchaddress = Console.ReadLine();
            Console.Write("Enter Branch Code : ");
            branchcode = Console.ReadLine();
        }
        public void displayinfo() { Console.WriteLine("\n\nEmployee ID: {3} \nEmployee Name: {4}\nBranch Code : {0}\nBranch Name : {1}\nBranch Address : {2} ", branchcode, branchname, branchaddress, empid, empname); }

        public void Calculate()
        {
            int a = 10;
            int b = 20;
            int c = a + b;
            Console.WriteLine("Calculate Method with no paramenters: \nSum of a+b = {0}",c);
        }

        public void Calculate(int m, int n)
        {
            int a = m;
            int b = n;
            int c = a + b;
            Console.WriteLine("\nCalculate Method with 2 paramenters: \nSum of a+b = {0}", c);
        }

    }

    class DoCalculationsInParent
    {
        public virtual void CalculateValue(int A, int B)
        {
            Console.WriteLine("Parent class ClaculateValues method is called and value = {0}", (A+B));
        }
    }

    class DoCalculationsInChild: DoCalculationsInParent
    {
        public override void CalculateValue(int A, int B)
        {
            Console.WriteLine("Child class ClaculateValues method is called and value = {0}", (A + B));
        }
    }

    class Program1
    {
        static void Main(string[] args)
        {
            A obj = new A();
            obj.Empdata();
            obj.GetBranchinfo();
            obj.displayinfo();
            Console.WriteLine("\n\nOverLoading Examples:");
            obj.Calculate();
            obj.Calculate(20, 30);
            Console.WriteLine("\nOverriding Examples:");
            DoCalculationsInParent objParent = new DoCalculationsInChild();
            DoCalculationsInParent objParent1 = new DoCalculationsInParent();
            objParent.CalculateValue(10, 20);
            objParent1.CalculateValue(10, 20);
            Console.ReadKey();
        }
    }
}