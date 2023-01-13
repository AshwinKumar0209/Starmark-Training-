using System;
namespace SampleConApp
{
    class Assign
    {

        static void Main(string[] args)
        {
            Console.WriteLine("ENter the size");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] num = new int[n];
            for(int i=1;i<=n;i++)
            {
                num[i] =Convert.ToInt32( Console.ReadLine());
            }

            for(int i = 1; i < num.Length+1; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{i} is even");
                }
                else
                {
                    Console.WriteLine($"{i} is odd");
                }
            }
        }
    }
}