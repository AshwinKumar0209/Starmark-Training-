using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Datatypes
    {
        static void Main()
        {
            Console.WriteLine("ENTRY into DataTypes");
            Console.WriteLine("Do prefer CONVERT class for casting variables");
            Console.WriteLine("-------------------------------------------------------------------");


            Console.WriteLine($"The range of byte is {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"The range of byte is {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"The range of byte is {long.MinValue} to {long.MaxValue}");


            Console.WriteLine("INTO TYPE CASTING");

            byte val = 3;
            int val1 = val;
            Console.WriteLine("Before CASTING is " + val1.GetType());
            Console.WriteLine("Before CASTING is " + val.GetType());

            //val = val1; //HERE U DO TYPE CASTING TO AVOID COMPATABILITY PROBLEM
            val = Convert.ToByte(val1);
            Console.WriteLine("AFTER CASTING is " + val.GetType());
            val1 = (int)val;


        }
    }
}

