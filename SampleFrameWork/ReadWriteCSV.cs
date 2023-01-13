using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SampleFrameWork.Practical;
using SampleConApp;
using System.Threading;

namespace SampleFrameWork
{
    class ReadWriteCSV
    {
        const string filename = "../../Customers.csv";
        static void Main(string[] args)
        {
            RETRY:
            string choice = utilities.Prompt("Enter A to Read and B to Write");
            switch (choice)
            {
                case "A":
                    writingExample();
                    break;
                case "B":
                    readingExample();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto RETRY;
            }
            
            
        }

        private static void writingExample()
        {
            Customer cst = new Customer
            {
                CustName = utilities.Prompt("Enter the Customer Name"),
                CustAdd = utilities.Prompt("Enter Customer Address"),
                CustId = utilities.GetNumber("Enter Customer ID"),
                BillAmt = utilities.GetNumber("Enter Bill Amount")
            };
            File.AppendAllText(filename, cst.ToString());
        }

        private static void readingExample()
        {
            List<Customer> AllCustomers = new List<Customer>();
            var AllLines = File.ReadAllLines(filename);
            foreach (var lines in AllLines)
            {
                var words = lines.Split(',');//single quotes because it is a single character
                Customer cst = new Customer();
                cst.CustName = words[1];
                cst.CustId =int.Parse( words[0]);
                cst.CustAdd = words[2];
                cst.BillAmt = int.Parse(words[3]);
                AllCustomers.Add(cst);
            }
            foreach (var cst in AllCustomers)
            {
                Console.WriteLine(cst.CustName);
            }
        }
    }
}
