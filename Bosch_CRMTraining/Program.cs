using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch_CRMTraining
{
    static class AreaRectAndCircle
    {
        public static decimal CalculateAreaOfCircle(decimal radius)
        {
            return ((3.14M) * (radius * radius));
        }

        public static int CalculateAreaOfRectangle(int length, int breadth)
        {
            return (length * breadth);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Enter 1 to calclate Area of Rectangle." +
                "\n2. Enter 2 to calculate Area of Cicle.\nPlease enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1 || choice == 2)
            {
                if (choice == 1)
                {
                    Console.WriteLine("Enter Lenght of Rectanlge:");
                    int length = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Breadth of Rectanlge:");
                    int breadth = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Area of Rectangle = {0}", AreaRectAndCircle.CalculateAreaOfRectangle(length, breadth));
                }
                else
                {
                    Console.WriteLine("Enter radius of circle:");
                    decimal radius = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Area of Circle = {0}", AreaRectAndCircle.CalculateAreaOfCircle(radius));
                }
            }
            else
            {
                Console.WriteLine("You have entered and invalid choce..");
            }
            Console.ReadLine();
        }
    }
}