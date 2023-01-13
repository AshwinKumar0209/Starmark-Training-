using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    enum WeekDays { MON , TUE , WED , THUR , FRI };
    class EnumExample
    {
       static  void Main()
        {
            Console.WriteLine("Welcome to Starmark");
            Console.WriteLine("Please enter the day to reach office");

            Console.WriteLine();

            Array PossibleDay = Enum.GetValues(typeof(WeekDays));
            foreach (object i in PossibleDay)  //IN CLASS IT IS DONE USING FOR LOOP 
            {
                Console.WriteLine(i);
            }
            object input = Enum.Parse(typeof(WeekDays), Console.ReadLine(),true);
            WeekDays SelectedDay = (WeekDays)input;

            Console.WriteLine("The Selected day is " + SelectedDay);
        }
    }
}
