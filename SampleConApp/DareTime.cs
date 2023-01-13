using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class DareTime
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);
            Console.WriteLine(dt.ToLongDateString());
            Console.WriteLine(dt.ToShortDateString());


            Console.WriteLine(dt.ToShortTimeString());
            Console.WriteLine(dt.ToLongTimeString());
            Console.WriteLine(dt.ToString());


            Console.WriteLine(dt.ToOADate());
            Console.WriteLine(dt.ToUniversalTime());


            Console.WriteLine("Enter the date in dd/mm/yyyy");
            dt = DateTime.ParseExact(Console.ReadLine(), "dd/mm/yyyy", null);
            Console.WriteLine(dt);

            var currDate = DateTime.Now;
            var span = DateTime.Now - dt;
            Console.WriteLine("The no of days: "+span.TotalDays);
            Console.WriteLine("the no of hours: "+span.TotalHours);
            Random random = new Random();
            for(int i = 0; i < 20; i++)
            {
                int no = random.Next(10, 20);
                Console.WriteLine("The Date ENtered: "+ currDate.AddDays(no).ToLongDateString());
                Thread.Sleep(2000);
            }
           
        }
    }
}
