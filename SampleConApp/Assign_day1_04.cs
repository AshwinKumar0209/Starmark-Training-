using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assign_day1_04
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter CTS Equivalent name of the type of array that you need");
            string TypeName = Console.ReadLine();
            Type type = Type.GetType(TypeName, true, true);
            Array MyArray = Array.CreateInstance(type, size);


            for(int i=0;i<size;i++)
            {
                Console.WriteLine($"ENter the values of{type.Name}");
                string EnteredValue = Console.ReadLine();
                object ConvertedValue = Convert.ChangeType(EnteredValue, type);
                MyArray.SetValue(ConvertedValue, i);
            }

            Console.WriteLine("All the values are set");
            foreach(object item in MyArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
