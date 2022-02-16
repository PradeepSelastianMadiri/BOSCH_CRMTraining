using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feb16_2022_DictionaryExample
{
    public class employee
    {
        public int id
        {
            get; set;
        }
        public string name
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public double salary
        {
            get;
            set;
        }

    }

    class DictionaryEx
    {
        public static void Main(string[] args)
        {
            employee emp = new employee()
            {
                id = 101,
                name = "amit",
                Gender = "male",
                salary = 20000

            };
            employee emp1 = new employee()
            {
                id = 102,
                name = "deepti",
                Gender = "Female",
                salary = 20

            };
            employee emp3 = new employee()
            {
                id = 103,
                name = "deepa",
                Gender = "Female",
                salary = 20333
            };
            //List<employee> em = new List<employee>();
            //em.Add(emp);
            //em.Add(emp1);
            //em.Add(emp3);

            Dictionary<int, employee> dct = new Dictionary<int, employee>();
            dct.Add(emp1.id, emp1);
            dct.Add(emp.id, emp);
            dct.Add(emp3.id, emp3);


            Console.WriteLine("retrieving the first employyee data ");

            foreach (KeyValuePair<int, employee> emplkey in dct)
            {
                Console.WriteLine("Key = " + emplkey.Key);
                employee emppp = emplkey.Value;
                Console.WriteLine("ID = {0},Name ={1} ,gender ={2} ,Salary ={3}", emppp.id, emppp.name, emppp.Gender, emppp.salary);

            }
        }
    }
}
