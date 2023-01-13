using System;
using System.Collections.Generic;
using System.Linq;
using SampleConApp;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    delegate double ArthWork(double FirstValue, double SecondValue); //Signature of the Delegate

    class MathOperation
    {
        public static void Operation(ArthWork Opera)
        {
            double FirstValue = utilities.GetNumber("Enter FirstValue");
            double SecondValue = utilities.GetNumber("Enter SecondValue");
            var res = Opera(FirstValue, SecondValue);
            Console.WriteLine("The result is "+res);
        }
    }

    class Delegates
    {
        static double Add(double FirstValue,double SecondValue)
        {
            return FirstValue + SecondValue;
        }
        static void Main(string[] args)
        {
            MathOperation.Operation(new ArthWork(Add));
            MathOperation.Operation(delegate (double FirstValue, double SecondValue)
            {
                return FirstValue * SecondValue;
            });
            MathOperation.Operation((FirstValue, SecondValue) => FirstValue - SecondValue);
                }
    }
}
