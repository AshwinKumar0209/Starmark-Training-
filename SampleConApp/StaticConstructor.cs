using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

  class StaticExample {

        internal static int value;
        static  StaticExample()
        {
            Console.WriteLine("Static Constructor");
        }

        
       public  StaticExample()
        {
            value = 11;
            Console.WriteLine("Instance Constructor");
        }


    }

    static class SingletonClass
    {
       public static void SingletonClass1()
        {
            Console.WriteLine("Static Method");
        }
    }

    class StaticConstructor
    {

        static void Main(string[] args)
        {
            StaticExample example = new StaticExample();
            example = new StaticExample();
            example = new StaticExample();
            example = new StaticExample();
            example = new StaticExample();
            example = new StaticExample();
            StaticExample.value  = 11; //it invokes static constructor only not the instance constructor
            SingletonClass.SingletonClass1(); 
        }
    }
}
