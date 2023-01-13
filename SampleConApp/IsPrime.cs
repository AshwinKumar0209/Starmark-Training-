using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class IsPrime
    {



        static int Main(string[] args)
        {
            int PrimeNum = utilities.GetNumber("Enter the number to be checked");
            if (Prime(PrimeNum))
            {
                Console.WriteLine("Prime Number");
                return 0;
            }
            Console.WriteLine("Not Prime");
            return 0;
        }

        internal static bool Prime(int PrimeNum)
        {   
            int count = 0;
            for(int i = 2; i < PrimeNum%2; i++)
            {
                if (PrimeNum % i == 0)
                {
                    count = 0;
                }
                else {
                    count = 1;
                }
            }
            if (count == 1)
            {
                return true;
            }
            return false;
            
        }
    }
}
