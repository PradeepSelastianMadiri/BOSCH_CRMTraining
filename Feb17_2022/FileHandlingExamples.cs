using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplaesExplainedByMentorInSession
{
    
    class WriteData
    {
        public void data()
        {
            string filepath = "C:\\First.txt";
            try
            {

                using (StreamWriter sw = File.AppendText(filepath))
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
                Console.WriteLine(File.ReadAllText(filepath));
            }
        }

        public void copy()
        {
            string src = "C:\\First.txt";
            string des = "D:\\First.txt";
            try
            {
                File.Move(src, des);
                File.Copy(des, src);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteData w = new WriteData();
            w.data();
            w.copy();
            Console.ReadKey();
        }
    }
}
