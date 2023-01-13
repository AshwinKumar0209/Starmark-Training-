using System;
using System.Diagnostics;
namespace SampleConApp
{
    class Sample
    {

        static void Main()
        {
            Console.WriteLine(" Hi WELCOME C#");
            Console.WriteLine("Lets see Basic info program");
            Console.WriteLine("Each inputs are taken as Strings");
            Console.WriteLine("ReadLine func() is used to pull inputs from user\n");


            Console.WriteLine("\nEnter details");

            Console.WriteLine("Enter Name:");
            String name = Console.ReadLine();

            Console.WriteLine("Enter Address: ");
            String add = Console.ReadLine();

            Console.WriteLine("Enter Salary");
            String sal = Console.ReadLine();

            Debug.WriteLine("Entry is DOne");

            Console.WriteLine("\nThe name is: " + name + "\nAt " + add + "\nEarning: " + sal+"\n");

            Console.WriteLine($"The name is {name} At {add} Earning {sal}");



        }
    }
}
