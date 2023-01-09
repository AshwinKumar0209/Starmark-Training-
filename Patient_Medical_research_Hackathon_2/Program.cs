using System;
using System.Collections;
using SampleConApp;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList list = new ArrayList();
            list.Add("Ashwin");
            list.Add("prajit");
            list.Add("Hemanth");
            list.Add("Aravindh");

            Console.WriteLine("number of names present {0}",list.Count);
            foreach (var item in list)
            {
                Console.WriteLine(item);

            }

    
        }
    }
}
