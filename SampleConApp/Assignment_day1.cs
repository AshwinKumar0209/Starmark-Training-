using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assignment_day1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("ENter the size");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] num = new int[n];
            for (int i = 0; i < n; i++)
            {
                num[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                if (num[i] % 2 == 0)
                {
                    Console.WriteLine($"{num[i]} is even");
                }
                else
                {
                    Console.WriteLine($"{num[i]} is odd");
                }
            }

        }
    }
}
