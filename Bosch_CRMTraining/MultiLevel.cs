using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch_CRMTraining
{
    public interface IRectangle
    {
        void AreaOfRectangle();
    }

    public class AreaRectAndCircle1
    {
        public int length = 0;
        public int breadth = 0;
        public decimal radius = 0.0M;


    }
    public class Child1 : AreaRectAndCircle1
    {
        public void CalculateAreaOfRectangle()
        {
            Console.WriteLine("Area of Rectangle:{0}", (length * breadth));
        }

    }

    //public class child2: Child1
    //{

    //    protected void CalculateAreaOfCircle()
    //    {
    //        Console.WriteLine("Area of Circle: {0}", ((3.14M) * (radius * radius)));

    //    }

    //}

    class MultiLevelExample
    {
        public static void Main()
        {
            Child1 c2 = new Child1();
            c2.length = 10;
            c2.breadth = 20;
            c2.radius = 2.0M;
            c2.CalculateAreaOfRectangle();
            //c2.CalculateAreaOfCircle();
            Console.ReadLine();

        }

    }
}
