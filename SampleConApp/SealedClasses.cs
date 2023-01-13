using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{  sealed  class ClassA 
    {
        public void Impl()
        {
            Console.WriteLine("Hi from ClassA");
        }
        }

    //class ClassB : ClassA // sealed classes cannot be inherited .
    class  ClassB
    {
        public virtual void Impl()
        {
            Console.WriteLine("Hi from class B");
        }
    } 

    class ClassC : ClassB
    {
        public sealed override void Impl()
        {
            Console.WriteLine("Hi from sealed overriden method");
        }
    }


    class SealedClasses
    {

        static void Main(string[] args)
        {
            ClassB classc = new ClassB();
            classc.Impl();

            classc = new ClassB();
            if(classc is ClassB)
            {
                var copy = classc as ClassC;
                copy.Impl();
            }



            //ClassB classb = new ClassB();
            //classb.Impl();

        }
      


    }
}
