using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class AssignDatetime
    {
        static void Main(string[] args)
        {
            DateTime UserDate = DateTime.Parse(utilities.Prompt("ENter Date in DD/MM/YYY format"));
            Console.WriteLine(UserDate);
            Console.WriteLine(UserDate.AddDays(365));
        }

    }
}
