using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class EX_05Arrays
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("WELCOME TO ARRAYS");
            //Console.WriteLine("Enter total number");
            //int n = Convert.TOConsole.ReadLine();
            //String[] names = new string[n];
            //Console.WriteLine("ENter names");
            //for (int i=0;i<n;i++)
            //{
            //    names[i] = Console.ReadLine();
            //}
            //Console.WriteLine("The names are listed below");
            //foreach (var item in names)
            //{
            //    Console.WriteLine(item);
            //}

            //2D Array
            int[,] num = new int [3,3];
            Console.WriteLine("Enter values");
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    num[i,j] =Convert.ToInt32( Console.ReadLine());
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(num[i,j]);
                }
                Console.WriteLine();
            }

        }
    }
}
