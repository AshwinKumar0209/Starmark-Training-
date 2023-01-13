using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{   interface IBase1 {
        void create();

    }
    interface IBase2
    {
        void Create2();
    }

    class SimpleExample : IBase1 , IBase2
    {
        public void create()
        {
            Console.WriteLine("General Implementation");
        }
        void IBase2.Create2() => Console.WriteLine("From Base 2");
    } 
    class Interface
    {
        static void Main(string[] args)
        {
            SimpleExample simEx = new SimpleExample();
            simEx.create();

            IBase1 ex = new SimpleExample();
            ex.create();
            IBase2 msg = new SimpleExample();
            msg.Create2();
        }
    }
}
