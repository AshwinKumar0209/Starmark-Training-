using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

    class Account {

        public int AccNo { get; set; }
        public string AccName { get; set; }
        public int AccBalance { get; set; }
    }

    class SBAccount : Account
    {
        public void Credit(int amount) => AccBalance += amount;

        public void Debit(int amount) => AccBalance -= amount;

    }
    class RDAccount : SBAccount
    {
        int amount = 5000;
        public void MakePayment()
        {
            Console.WriteLine($"Payment of Rs. {amount} is done");
            AccBalance += amount;
        }
    }



    class Inheritance
    {
        static void Main(string[] args)
        {
            SBAccount acc = new SBAccount { AccName = "testName", AccNo = 123 };
            acc.Credit(45000);
            acc.Debit(5000);
            Console.WriteLine("The Balance : " + acc.AccBalance);


            RDAccount obj = new RDAccount { AccNo = 3306, AccBalance = 100000, AccName = "Vijay" };
            obj.Credit(33333);
            Console.WriteLine(obj.AccBalance);
        }
    }
}
