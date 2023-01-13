using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Baseclass {
        public void basefunc() => Console.WriteLine("From BaseClass");
    }
    class DerivedClass : Baseclass
    {
        public void Basefunc() => Console.WriteLine("From Derived Class");
        public  void Derivedfunc() => Console.WriteLine("From Derived Class");
    }


    class _05_Method_Overriding
    {
        static void Main(string[] args)
        {
            Baseclass instance = new DerivedClass();
            instance.basefunc();
            //instance.Basefunc() // here the function from BaseClass is triggered  and collections or functions in Derived Class are Hidden this is called Method Hiding.
            // so create a instance of derived class to access functions present in derived class
            if(instance is DerivedClass) // is operator is used to check that instance holds the type of derivedclass.
            {
                DerivedClass copy = instance as DerivedClass;
                copy.basefunc();
                copy.Basefunc();
                copy.Derivedfunc();
            }

            Console.WriteLine("---------------------------------------------------------------");

            DerivedClass Derive = new DerivedClass();  // private functions or feilds are not accessable from derived class which are in baseclass  
            Derive.Basefunc();
            Derive.basefunc();

        }


    }
}
