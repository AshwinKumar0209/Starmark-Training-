using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{   class MathOperations
    {
        public long Addfunc(int val1, int val2)  //InSTANCE METHOD 
        {
            long res = val1 + val2;
            return res;
        }

        public void SquareRoot(int InVal, ref double SqrVal, ref double SqrRoot)
        {
            SqrVal = InVal * InVal;
            SqrRoot = Math.Sqrt(InVal);
        }
        public void MathFunc(double v1, double v2, out double addedValue, out double subtractedValue, out double multipliedValue, out double divValue)
        {
            addedValue = v1 + v2;
            subtractedValue = v1 - v2;
            multipliedValue = v1 * v2;
            if (v2 != 0)
                divValue = v1 / v2;
            else
                throw new DivideByZeroException();
        }


    }


    class Day2_Function
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INSTANCE METHOD");
            int val1 =int.Parse( Console.ReadLine());
            int val2 = int.Parse(Console.ReadLine());
            MathOperations obj = new MathOperations();
            Console.WriteLine("The result is " + obj.Addfunc(val1, val2));

            int ival = 7; // REFERNCE METHOD 
            double fval = 0, sval = 0;
            obj.SquareRoot(ival, ref fval, ref sval);
            Console.WriteLine($"the fval:{fval} and sval:{sval}");

            int firstValue = 123, secondValue = 12;// OUT METHOD
            double addedVal, subVal, mulVal, divVal;
            obj.MathFunc(firstValue, secondValue, out addedVal, out subVal, out mulVal, out divVal);
            Console.WriteLine($"The Added value: {addedVal}\nSubtracted Value: {subVal}\nThe multiplied Value: {mulVal}\nThe Divided Value: {divVal: ##.##}");

        }

    }
}
