using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feb17_2021
{
    public delegate AccountDetails TransactionDelegate(int userChoice, AccountDetails objAcDtls);
    public delegate void CreateCustomerBankAccount(ref AccountDetails objAD);

    #region AccountDetails class
    public class AccountDetails
    {
        public int AccountTypeID = 0;
        public int CustomerID = 0;
        public string AccountHolderName = string.Empty;
        public string ParentAccountName = string.Empty;
        public string Address = string.Empty;
        public int Age = 0;
        public decimal AccountBalance = 0.0M;
        public int ErrorTypeID = 0;
        public string ErrorMessage = string.Empty;
        public int TransactionPerDay = 0;
        public bool IsATMRequired = false;
    }
    #endregion

    #region Create Account Class
    class BankAccountOperatons
    {

        public void CreateAccountByTypeId(ref AccountDetails objAD)
        {
            try
            {
                Console.WriteLine();
                switch (objAD.AccountTypeID)
                {
                    case 1:

                        Console.WriteLine("Please Enter Savings Bank Account Details: ");
                        Console.WriteLine("==============================================");
                        objAD = CapturerCustomerDetails(objAD);

                        break;

                    case 2:
                        Console.WriteLine("Please Enter Current Bank Account Details: ");
                        Console.WriteLine("============================================== ");
                        objAD = CapturerCustomerDetails(objAD);

                        break;

                    case 3:
                        Console.WriteLine("Please Enter Child Bank Account Details: ");
                        Console.WriteLine("============================================== ");
                        objAD = CapturerCustomerDetails(objAD);

                        break;
                }
            }
            catch (Exception ex)
            {
                objAD.ErrorMessage = "There is an error while creating the account: " + ex.Message;
                objAD.ErrorTypeID = 1;
            }
        }

        public AccountDetails CapturerCustomerDetails(AccountDetails accountDetails)
        {
            try
            {
                if (accountDetails.AccountTypeID == 3)
                {
                    Console.Write("Enter Parent Account Holder Name: ");
                    accountDetails.ParentAccountName = Console.ReadLine();
                }
                Console.Write("Enter Customer ID: ");
                accountDetails.CustomerID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your Name: ");
                accountDetails.AccountHolderName = Console.ReadLine();
                Console.Write("Enter your Age: ");
                accountDetails.Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your Address: ");
                accountDetails.Address = Console.ReadLine();
                Console.Write("Enter your initial deposit amount: ");
                accountDetails.AccountBalance = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Do you want an ATM Card (Enter 1 for Yes. Enter 2 for No): ");
                int ATMId = Convert.ToInt32(Console.ReadLine());
                accountDetails.IsATMRequired = ATMId == 1 ? true : false;

                if (accountDetails.AccountTypeID == 1)
                {
                    if (accountDetails.AccountBalance > 100000)
                    {
                        accountDetails.ErrorTypeID = 2;
                        accountDetails.ErrorMessage = "For Savings Bank Account the limit is 100000, please try again later.\nThank you for Banking with us, have a great day.";
                    }
                }
                else if (accountDetails.AccountTypeID == 2)
                {
                    if (accountDetails.AccountBalance > 200000)
                    {
                        accountDetails.ErrorTypeID = 2;
                        accountDetails.ErrorMessage = "For Current Bank Account the limit is 200000, please try again later.\nThank you for Banking with us, have a great day.";
                    }
                }
                else if (accountDetails.AccountTypeID == 3)
                {
                    if (accountDetails.AccountBalance > 50000)
                    {
                        accountDetails.ErrorTypeID = 2;
                        accountDetails.ErrorMessage = "For Child Bank Account the limit is 50000, please try again later.\nThank you for Banking with us, have a great day.";
                    }
                }

            }
            catch (Exception ex)
            {
                accountDetails.ErrorMessage = "There is an error while creating the account: " + ex.Message;
                accountDetails.ErrorTypeID = 1;
            }

            return accountDetails;
        }

        public void DisplayCustomerDetails(ref AccountDetails objAcDtls)
        {
            if (objAcDtls.ErrorTypeID > 0)
            {
                Console.WriteLine(objAcDtls.ErrorMessage);
            }
            else
            {
                int id = objAcDtls.AccountTypeID;

                Console.WriteLine("\n****************************************************************");
                Console.WriteLine("Congratulations Your Account has been created successfully...");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("Account Type\t= {0}", id == 1 ? "Savings" : (id == 2 ? "Current" : "Child"));
                if (objAcDtls.AccountTypeID == 3)
                {
                    Console.WriteLine("Parent Account Name\t = {0}", objAcDtls.ParentAccountName);
                }
                Console.WriteLine("Account Name\t= {0}", objAcDtls.AccountHolderName);
                Console.WriteLine("Age  \t= {0}", objAcDtls.Age);
                Console.WriteLine("Address  \t= {0}", objAcDtls.Address);
                Console.WriteLine("A/C Balance\t= {0}", objAcDtls.AccountBalance);
                if (objAcDtls.IsATMRequired)
                {
                    Console.WriteLine("Opted for ATM\t= {0}", objAcDtls.IsATMRequired);
                }
                Console.WriteLine("****************************************************************");
            }
        }

        public AccountDetails PerformATMTransactions(int choice, AccountDetails objACDtls)
        {
            switch (choice)
            {
                case 1:
                    Console.Write("Please enter amount to be deposited: ");
                    decimal depAmt = Convert.ToDecimal(Console.ReadLine());
                    objACDtls.AccountBalance = objACDtls.AccountBalance + depAmt;
                    Console.WriteLine("\nYour Update balance\t= {0}", objACDtls.AccountBalance);
                    objACDtls.TransactionPerDay = objACDtls.TransactionPerDay + 1;
                    break;

                case 2:
                    Console.Write("Please enter amount to be deposited: ");
                    decimal wdAmt = Convert.ToDecimal(Console.ReadLine());
                    objACDtls.AccountBalance = objACDtls.AccountBalance - wdAmt;
                    Console.WriteLine("\nYour Update balance\t= {0}", objACDtls.AccountBalance);
                    objACDtls.TransactionPerDay = objACDtls.TransactionPerDay + 1;
                    break;
                case 3:
                    Console.WriteLine("\nYour Available Balance is\t: {0}", objACDtls.AccountBalance);
                    break;
            }

            return objACDtls;
        }

        public void DisplayAllCustomerDetails(List<AccountDetails> lstAccounts)
        {
            string filepath = @"C:\Users\adminvm.adminvm\source\repos\Bosch_CRMTraining\Feb17_2022\Files\CustomerDetails.txt";

            using (StreamWriter sw = File.AppendText(filepath))
            {
                int SNO = 0;

                Console.WriteLine("||********************************************************************************************************||");
                Console.WriteLine("||CID  ||  A/C Type  ||  \tA/C Name\t  ||  Age  ||  \tAddress\t\t  ||  Balance    ||  ATM  ||");
                Console.WriteLine("||********************************************************************************************************||");

                sw.WriteLine("||********************************************************************************************************||");
                sw.WriteLine(Environment.NewLine + "||CID  ||  A/C Type  ||  \tA/C Name\t  ||  Age  ||  \tAddress\t\t  ||  Balance    ||  ATM  ||");
                sw.WriteLine(Environment.NewLine + "||********************************************************************************************************||");

                foreach (AccountDetails objAC in lstAccounts)
                {
                    SNO = SNO + 1;
                    int id = objAC.AccountTypeID;
                    Console.Write("||  " +
                        objAC.CustomerID + "  ||  " +
                        (id == 1 ? "Savings" : (id == 2 ? "Current" : "Child  ")) + "   ||" + "   \t" +
                        objAC.AccountHolderName + "  \t\t" + "  ||  " + objAC.Age + "   ||  " + objAC.Address + "   \t\t  ||  " + objAC.AccountBalance + "      ||  " +
                        (objAC.IsATMRequired ? "Yes" : "NO ") + "  ||"
                        );
                    Console.WriteLine("\n||--------------------------------------------------------------------------------------------------------||");

                    sw.Write(Environment.NewLine +
                        "||  " +
                        objAC.CustomerID + "  ||  " +
                        (id == 1 ? "Savings" : (id == 2 ? "Current" : "Child  ")) + "   ||" + "   \t" +
                        objAC.AccountHolderName + "  \t\t" + "  ||  " + objAC.Age + "   ||  " + objAC.Address + "   \t\t  ||  " + objAC.AccountBalance + "      ||  " +
                        (objAC.IsATMRequired ? "Yes" : "NO ") + "  ||"
                    );
                    sw.Write(Environment.NewLine + "||--------------------------------------------------------------------------------------------------------||");
                   
                }
                sw.Close();
            }
        }

        public void DisplayCustomerDetailsByID(List<AccountDetails> lstAccounts)
        {
            Console.Write("Enter Customer ID:");
            int cid = Convert.ToInt32(Console.ReadLine());
            if (lstAccounts.Count > 0)
            {
                var customerDetails = lstAccounts.Where(x => x.CustomerID == cid).ToList();

                if (customerDetails != null)
                {
                    List<AccountDetails> acFound = new List<AccountDetails>();
                    acFound.Add(customerDetails[0]);
                    DisplayAllCustomerDetails(acFound);
                }
            }
        }

        public void ReachingTransactionLimit(AccountDetails objACDtls)
        {
            Console.WriteLine("\nYou have reached daily transaction limit (i.e: 3), so Amount of 500 is being deducted from your account.");
            Console.WriteLine("Balance before deductions\t = {0}", objACDtls.AccountBalance);
            objACDtls.AccountBalance = objACDtls.AccountBalance - 500;
            Console.WriteLine("Available balance\t = {0}", objACDtls.AccountBalance);
        }
    }
    #endregion

    class Feb172021
    {
        static void Main(string[] args)
        {
            BankAccountOperatons bAO = new BankAccountOperatons();
            int userChoise = 0;
            List<AccountDetails> lstCustomerAccounts = new List<AccountDetails>();
            AccountDetails objACDtls = null;

            try
            {

                while (userChoise >= 0)
                {
                    if (userChoise == 0)
                    {
                        Console.Write("1. Enter 1 to open Savings Bank A/C. \n2. Enter 2 to open Current Bank A/C.\n3. Enter 3 to open Child Bank A/C.\nPlease choose your account type: ");
                        userChoise = Convert.ToInt32(Console.ReadLine());

                        objACDtls = new AccountDetails();
                        //lstCustomerAccounts.Add(objACDtls);
                        objACDtls.AccountTypeID = userChoise;
                    }

                    if (userChoise > 0 && userChoise <= 3)
                    {
                        CreateCustomerBankAccount objCrtCstData = new CreateCustomerBankAccount(bAO.CreateAccountByTypeId);
                        objCrtCstData += bAO.DisplayCustomerDetails;
                        objCrtCstData(ref objACDtls);
                        lstCustomerAccounts.Add(objACDtls);
                        //ca.CreateAccountByTypeId(ref objACDtls);
                        //ca.DisplayCustomerDetails(ref objACDtls);

                        if (objACDtls.IsATMRequired)
                        {
                            int intoperation = 0;

                            while (intoperation >= 0 && intoperation <= 3)
                            {
                                Console.WriteLine("\nAs you have opted for ATM facility, please select below operation to perform:\n1. Deposit.\n2. Withdraw.\n3. Check Available Balance.\n4. Exit ATM.");
                                Console.Write("Enter your choice: ");
                                intoperation = Convert.ToInt32(Console.ReadLine());

                                if (intoperation >= 1 && intoperation <= 3)
                                {
                                    TransactionDelegate objDel = new TransactionDelegate(bAO.PerformATMTransactions);
                                    objACDtls = objDel(intoperation, objACDtls);

                                    if (objACDtls.TransactionPerDay > 3)
                                    {
                                        bAO.ReachingTransactionLimit(objACDtls);
                                    }
                                }

                                if (intoperation < 4)
                                {
                                    Console.WriteLine("\n\n****************************************************************");
                                    Console.WriteLine("Enter 0 to do another transaction or enter 4 to exit ATM.");
                                    intoperation = Convert.ToInt32(Console.ReadLine());
                                }

                            };
                        }

                    }
                    else if (userChoise > 3)
                    {

                        if (userChoise == 4)
                            bAO.DisplayAllCustomerDetails(lstCustomerAccounts);
                        else
                            bAO.DisplayCustomerDetailsByID(lstCustomerAccounts);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice...");
                    }

                    Console.WriteLine("\n\n****************************************************************");
                    Console.WriteLine("Enter 0 to Create account.\nEnter 4 to display all customer details.\n5.Search Customer by id.\nEnter -1 to exit.");
                    Console.Write("Enter Your choice: ");
                    userChoise = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("****************************************************************\n");


                };

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nInvalid input, please try again later...");
                Console.ReadKey();
            }

        }
    }
}
