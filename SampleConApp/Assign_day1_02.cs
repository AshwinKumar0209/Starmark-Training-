using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assign_day1_02
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Calculator Application");
            while (true)
            {
                Console.WriteLine("Enter varibales");
                int val1 = Convert.ToInt32(Console.ReadLine());
                int val2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ENter from menu below \n ADD\n SUB\nMUL\nDIV");
                String oper = Convert.ToString(Console.ReadLine());
                int res = 0;
               
                switch (oper)
                {
                    case "ADD":
                        {
                            res = val1 + val2;
                            Console.WriteLine("The addition is " + res);
                            break;
                        }
                    case "SUB":
                        {
                            res = val1 - val2;
                            Console.WriteLine("The Substraction is " + res);
                            break;
                        }
                    case "MUL":
                        {
                            res = val1 * val2;
                            Console.WriteLine("The Multiplication is " + res);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Sorry wrong option");
                            break;
                        }
                }
                Console.WriteLine("Enter YES or NO");
                        String choice = Console.ReadLine();

                        if (choice == "NO")
                        {
                            break;
                        }

              

            }


        }
    }
}
