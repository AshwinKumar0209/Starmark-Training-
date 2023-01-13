using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{  abstract  class BankAccount
    {
        public int AccNo { get; set; }
        public string AccName  { get; set; }

        public int AccBalance { get; set; } = 2000;
        public void Credit(int amount) => AccBalance += amount;
        public void Debit (int amount)
        {
            if (amount > AccBalance)
                throw new Exception("Insufficient Funds");
            AccBalance -= amount;
        }

        public abstract void CalculateInterest();
    }

    internal class SBAccount1 : BankAccount
    {
        public override void CalculateInterest()
        {
            var principal = AccBalance;
            var time = 0.25;
            var rate = 0.05;
            var Interest = principal * time * rate;
            Credit((int)Interest);
        }
    }
    internal class RDAccount1 : BankAccount
    {
        public override void CalculateInterest()
        {
            var principal = AccBalance;
            var time = 0.25;
            var rate = 0.1;
            var Interest = principal * time * rate;
            Credit((int)Interest);
        }
    }
    internal class FDAccount : BankAccount
    {
        public override void CalculateInterest()
        {
            var principal = AccBalance;
            var time = 0.25;
            var rate = 0.4;
            var Interest = principal * time * rate;
            Credit((int)Interest);
        }
    }

    class AccountFactory 
    {
       
        public void CreateAccount(string Type)
        {
            
            switch (Type)
            {
                case "SB":
                    SBInterest(); 
                        break;
                case "FD":
                     FDInterest();
                    break;
                case "RD":
                    RDInterest();
                    break;
                default:
                    throw new Exception("This Type of Account is Not With Us");
            }
        }
        public void SBInterest()
        {
            SBAccount1 interest = new SBAccount1();
            interest.CalculateInterest();
            Console.WriteLine("The SB interest is " + interest.AccBalance);
        }
        public void FDInterest()
        { 
            FDAccount interest = new FDAccount();
            interest.CalculateInterest();
            Console.WriteLine("The FD Interest is " + interest.AccBalance);
        }
        public void RDInterest()
        {
            RDAccount1 interest = new RDAccount1();
            interest.CalculateInterest();
            Console.WriteLine("The RD Interest is " + interest.AccBalance);

        }



    }
    class AbstractClass
    {

        static void Main(string[] args)

        {
            try
            {
                string AccType = utilities.Prompt("Enter Type");
                AccountFactory acc = new AccountFactory();
                acc.CreateAccount(AccType.ToUpper());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
