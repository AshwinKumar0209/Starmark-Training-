using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Business {
    public virtual void MakePayment(string PayMode, double Amount)
        {
            if (PayMode == "CreditCard")
            {
                Console.WriteLine("Payment Not Accepted");
            }
            else
                Console.WriteLine("Payment accepted by {1}  for {0}", Amount, PayMode);
        }
    }

    class TechBusiness : Business
    {
        public override void MakePayment(string payMode,double amount)
        {
            if(payMode == "Cheque")
            {
                Console.WriteLine("Payment is no longer accepted");
            }
            else
            {
                Console.WriteLine("Payment accepted by {1} for Rs.{0}",amount,payMode);
            }
        }
    }

    class BusinessFactory {
    public  static Business GetObject(string arg)
        {
            if (arg.ToUpper() == "BUSINESS")
                return new Business();
            else if (arg.ToUpper() == "TECHBUSINESS")
                return new TechBusiness();
            else
                throw new Exception("This type of Business is not available with us");
        }
    }


    class MethodOverriding
    {
        static void Main(string[] args)
        {
            string BussType = utilities.Prompt("Enter the type of business you need");
            Business Component = BusinessFactory.GetObject(BussType);
            Component.MakePayment("CreditCard", 5000);
            Component.MakePayment("Cheque", 5000);
        }

    }
}
