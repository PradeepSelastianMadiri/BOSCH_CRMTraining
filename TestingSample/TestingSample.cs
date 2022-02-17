using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    #region AccountDetails class
    public class AccountDetails
    {
        public int AccountTypeID = 0;
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

    class Testing
    {

        static void Main(string[] args)
        {

            #region Commented
            /*
                List<AccountDetails> lstCustAccounts = new List<AccountDetails>
                {
                    new AccountDetails(){AccountTypeID = 1, AccountHolderName = "MPS1", Address = "HYD1",Age=28,AccountBalance=20000,IsATMRequired=true},
                    new AccountDetails(){AccountTypeID = 2, AccountHolderName = "MPS2", Address = "HYD2",Age=28,AccountBalance=20000,IsATMRequired=false},
                    new AccountDetails(){AccountTypeID = 1, AccountHolderName = "MPS3", Address = "HYD3",Age=28,AccountBalance=20000,IsATMRequired=true},
                    new AccountDetails(){AccountTypeID = 3, AccountHolderName = "MPS4", Address = "HYD4",Age=28,AccountBalance=20000,IsATMRequired=false},
                    new AccountDetails(){AccountTypeID = 2, AccountHolderName = "MPS5", Address = "HYD5",Age=28,AccountBalance=20000,IsATMRequired=false}
                };

                Console.WriteLine("||********************************************************************************************************||");
                Console.WriteLine("||S.No ||  A/C Type  ||  \tA/C Name\t  ||  Age  ||  \tAddress\t\t  ||  Balance    ||  ATM  ||");
                Console.WriteLine("||********************************************************************************************************||");
                int SNO = 0;
                foreach (AccountDetails ad in lstCustAccounts)
                {
                    SNO = SNO + 1;
                    int id = ad.AccountTypeID;
                    Console.Write("||  " +
                        SNO + "  ||  " +
                        (id == 1 ? "Savings" : (id == 2 ? "Current" : "Child  ")) + "   ||" + "   \t" +
                        ad.AccountHolderName + "  \t\t" + "  ||  " + ad.Age + "   ||  " + ad.Address + "   \t\t  ||  " + ad.AccountBalance + "      ||  " +
                        (ad.IsATMRequired ? "Yes" : "NO ") + "  ||"
                        );
                    Console.WriteLine("\n||--------------------------------------------------------------------------------------------------------||");

                }

                */
            #endregion

            string strFileName = @"C:\Users\adminvm.adminvm\source\repos\Bosch_CRMTraining\TestingSample\Files\CustomerDetails.txt";

            try
            {

                using (StreamWriter sw = File.AppendText(strFileName))
                {
                    sw.Write(Environment.NewLine + "Appending this new line");
                    sw.Close();
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine(File.ReadAllText(strFileName));
            }

            Console.ReadKey();
        }
    }
}
