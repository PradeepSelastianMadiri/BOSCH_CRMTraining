using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class LimitExceedExcep : Exception
    {
        public LimitExceedExcep(string message) : base(message)
        {

        }

    }

    public class Customer
    {
        public string name
        {
            get;
            set;
        }
        public string gender
        {
            get;
            set;
        }
        public int age
        {
            get; set;
        }
        public string address
        {
            get;
            set;
        }
        public string contact
        {
            get;
            set;
        }
        public int balance
        {
            get;
            set;
        }

        public Customer CreateCustomer(Customer c1)
        {
            Console.Write("\nEnter Name: ");
            c1.name = Console.ReadLine();
            Console.Write("Enter Gender: ");
            c1.gender = Console.ReadLine();
            Console.Write("Enter Age: ");
            c1.age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Address: ");
            c1.address = Console.ReadLine();
            Console.Write("Enter Contact: ");
            c1.contact = Console.ReadLine();
            return c1;
        }
        public void displaydetails(List<Customer> lstAllCustomers)
        {
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("Customer Details are :");
            Console.WriteLine("------------------------------------------------");
            foreach (Customer c in lstAllCustomers)
            {
                Console.WriteLine("Name = {0}\t,Age = {1}\t,Gender = {2}\t,Address = {3}\t,Contact = {4}\tBalance = {5}", c.name, c.age, c.gender, c.address, c.contact, c.balance);
            }
        }
    }

    class Savings
    {
        int amount, balance = 0;
        static List<Customer> l = new List<Customer>();
        public void display()
        {
            Customer c1 = new Customer()
            {
                name = "Shakthi",
                age = 23,
                gender = "male",
                address = "Chennai",
                contact = "3451278909"

            };
            Customer c2 = new Customer()
            {
                name = "John",
                age = 26,
                gender = "male",
                address = "Bangalore",
                contact = "7825962909"

            };
            Customer c3 = new Customer()
            {
                name = "Divya",
                age = 27,
                gender = "female",
                address = "Coimbatore",
                contact = "7532850589"

            };

            l.Add(c1);
            l.Add(c2);
            l.Add(c3);

        }
        public void Deposit(Customer c1)
        {
            Console.WriteLine("Enter the amount to deposit");
            amount = Convert.ToInt32(Console.ReadLine());
            //if (l.Count > 0)
            //{
            //    l[0].balance = balance;
            //}
            c1.balance = c1.balance + amount;
            Console.WriteLine("Total Balance : {0}", c1.balance);
        }
        public void Withdraw(Customer c1)
        {
            Console.WriteLine("Enter the amount to withdraw");
            amount = Convert.ToInt32(Console.ReadLine());
            //if (l.Count > 0)
            //{
            //    l[0].balance = balance;
            //}
            c1.balance = c1.balance - amount;
            Console.WriteLine("Total Balance : {0}", c1.balance);
        }
        public void Deduct(Customer c1)
        {
            Console.WriteLine("\nSince you exceeded the daily transaction limit\nYou will be deducted Rs.500 from your account");
            c1.balance = c1.balance - 500;
            Console.WriteLine("Total Balance : {0}", c1.balance);
            Console.WriteLine();
            //if (l.Count > 0)
            //{
            //    l[0].balance = balance;
            //}
        }

    }

    class Current
    {
        int amount, balance = 10000;
        public void Deposit(Customer c1)
        {
            Console.WriteLine("Enter the amount to deposit");
            amount = Convert.ToInt32(Console.ReadLine());
            c1.balance = c1.balance + amount;
            Console.WriteLine("Total Balance : {0}", c1.balance);
        }
        public void Withdraw(Customer c1)
        {
            Console.WriteLine("Enter the amount to withdraw");
            amount = Convert.ToInt32(Console.ReadLine());
            c1.balance = c1.balance - amount;
            Console.WriteLine("Total Balance : {0}", c1.balance);
        }
        public void Deduct(Customer c1)
        {
            Console.WriteLine("Since you exceeded the daily transaction limit\n You will be deducted Rs.500 from your account");
            c1.balance = c1.balance - 500;
            Console.WriteLine("Total Balance : {0}", c1.balance);
        }

    }

    class Child
    {
        int amount, balance = 10000;

        public void Deposit(Customer c1)
        {
            Console.WriteLine("Enter the amount to deposit");
            amount = Convert.ToInt32(Console.ReadLine());
            c1.balance = c1.balance + amount;
            Console.WriteLine("Total Balance : {0}", c1.balance);
        }
        public void Withdraw(Customer c1)
        {
            Console.WriteLine("Enter the amount to withdraw");
            amount = Convert.ToInt32(Console.ReadLine());
            c1.balance = c1.balance - amount;
            Console.WriteLine("Total Balance : {0}", c1.balance);
        }
        public void Deduct(Customer c1)
        {
            Console.WriteLine("Since you exceeded the daily transaction limit\n You will be deducted Rs.500 from your account");
            c1.balance = c1.balance - 500;
            Console.WriteLine("Total Balance : {0}", c1.balance);
        }

    }
    class Program
    {

        static void Main(string[] args)
        {

            int choice = 0, n, count = 0;
            int CustChoice = 0;
            Savings s = new Savings();
            s.display();
            Current c = new Current();
            Child ch = new Child();
            Customer c1 = null;
            List<Customer> lstCustomers = new List<Customer>();
            Console.WriteLine(" Welcome to HDFC Bank :");
            Console.WriteLine(" ================================================== ");

            try
            {
                for (; CustChoice == 0;)
                {
                    count = 0;
                    if (CustChoice == 0)
                    {
                        Console.WriteLine(" To open : \n Savings Account -> Enter 1 \n Current Account -> Enter 2 \n Child Account -> Enter 3 ");
                        choice = Convert.ToInt32(Console.ReadLine());
                    }

                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine(" ============================================= ");
                                Console.WriteLine(" You have Choosen Savings Account :");

                                if (CustChoice == 0)
                                {
                                    c1 = new Customer();
                                    c1 = c1.CreateCustomer(c1);
                                    lstCustomers.Add(c1);
                                }

                                Console.WriteLine("===============================================");
                                Console.WriteLine("Your Savings Account Created Successfully....!");
                                Console.WriteLine("===============================================");

                            SavingsTransaction:

                                Console.WriteLine("Below are the options to do the transaction...");
                                Console.WriteLine("Deposit -> 1 \nWithdraw -> 2 ");
                                n = Convert.ToInt32(Console.ReadLine());

                                if (n == 1)
                                {
                                    if (count < 3)
                                    {
                                        s.Deposit(c1);
                                        count++;
                                    }
                                    else
                                    {
                                        s.Deduct(c1);
                                        throw (new LimitExceedExcep("Note : Your daily limit exceeded !!"));

                                    }
                                }

                                if (n == 2)
                                {
                                    if (count < 3)
                                    {
                                        s.Withdraw(c1);
                                        count++;
                                    }
                                    else
                                    {
                                        s.Deduct(c1);
                                        throw (new LimitExceedExcep("Note : Your daily limit exceeded !!"));

                                    }
                                }

                                if (n == 1 || n == 2)
                                {
                                    Console.WriteLine("Do you want do another transaction...?\nYes --> 1\n No --> 2");
                                    int intcontinue = Convert.ToInt32(Console.ReadLine());
                                    if (intcontinue == 1)
                                        goto SavingsTransaction;
                                }

                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine(" ========================== ");
                                Console.WriteLine(" You have Choosen Current Account :");

                                if (CustChoice == 0)
                                {
                                    c1 = new Customer();
                                    c1 = c1.CreateCustomer(c1);
                                    lstCustomers.Add(c1);
                                }

                                Console.WriteLine("===============================================");
                                Console.WriteLine("Your Current Account Created Successfully....!");
                                Console.WriteLine("===============================================");

                            CurrentTransaction:

                                Console.WriteLine("Below are the options to do the transaction...");
                                Console.WriteLine("Deposit -> 1 \nWithdraw -> 2 ");
                                n = Convert.ToInt32(Console.ReadLine());


                                if (n == 1)
                                {
                                    if (count < 3)
                                    {
                                        c.Deposit(c1);
                                        count++;
                                    }
                                    else
                                    {
                                        c.Deduct(c1);
                                        throw (new LimitExceedExcep("Note : Your daily limit exceeded !!"));
                                    }
                                }
                                if (n == 2)
                                {
                                    if (count < 3)
                                    {
                                        c.Withdraw(c1);
                                        count++;
                                    }
                                    else
                                    {
                                        c.Deduct(c1);
                                        throw (new LimitExceedExcep("Note : Your daily limit exceeded !!"));
                                    }
                                }

                                if (n == 1 || n == 2)
                                {
                                    Console.WriteLine("Do you want do another transaction...?\nYes --> 1\n No --> 2");
                                    int intcontinue = Convert.ToInt32(Console.ReadLine());
                                    if (intcontinue == 1)
                                        goto CurrentTransaction;
                                }

                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine(" ========================== ");
                                Console.WriteLine(" You have Choosen Child Account :");

                                if (CustChoice == 0)
                                {
                                    c1 = new Customer();
                                    c1 = c1.CreateCustomer(c1);
                                    lstCustomers.Add(c1);
                                }

                                Console.WriteLine("===============================================");
                                Console.WriteLine("Your Child Account Created Successfully....!");
                                Console.WriteLine("===============================================");

                            ChildTransaction:

                                Console.WriteLine("Below are the options to do the transaction...");
                                Console.WriteLine("Deposit -> 1 \nWithdraw -> 2 ");
                                n = Convert.ToInt32(Console.ReadLine());

                                if (n == 1)
                                {
                                    if (count < 3)
                                    {
                                        ch.Deposit(c1);
                                        count++;
                                    }
                                    else
                                    {
                                        ch.Deduct(c1);
                                        throw (new LimitExceedExcep("Note : Your daily limit exceeded !!"));
                                    }
                                }
                                if (n == 2)
                                {
                                    if (count < 3)
                                    {
                                        ch.Withdraw(c1);
                                        count++;
                                    }
                                    else
                                    {
                                        ch.Deduct(c1);
                                        throw (new LimitExceedExcep("Note : Your daily limit exceeded !!"));
                                    }
                                }

                                if (n == 1 || n == 2)
                                {
                                    Console.WriteLine("Do you want do another transaction...?\nYes --> 1\n No --> 2");
                                    int intcontinue = Convert.ToInt32(Console.ReadLine());
                                    if (intcontinue == 1)
                                        goto ChildTransaction;
                                }

                                break;
                            }
                        default:
                            {
                                Console.WriteLine(" Please enter a valid option");
                                break;
                            }
                    }

                    Console.WriteLine("Do you want to create another account...?\nYes --> Enter 0\nNo --> Enter 1");
                    CustChoice = Convert.ToInt32(Console.ReadLine());

                }
            }
            catch (LimitExceedExcep e)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("User Defined Exception {0}", e.Message);
            }
            c1.displaydetails(lstCustomers);

            Console.ReadKey();

        }

    }
}
