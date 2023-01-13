using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace SampleConApp
{
    class InvalidDate
    {
        static bool CheckLeap(int year,int month,int date)
        {
            if (month == 2)
            {
                if(year%4==0 && year%400 == 0)
                {
                    if (date <= 29)
                    {
                        return true;
                    }
                    return false;
                }
                else if (date < 29)
                        {
                    return true;
                }
            }

            return false;
        } 


       static public bool checked31(int year,int month,int date) {
            if(true)
            {
                if (month <= 12)
                {
                    if (date <= 31)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }


        static public bool checked30(int year, int month, int date)
        {
            if (true)
            {
                if (month <= 12)
                {
                    if (date <= 30)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }


        static bool isValidDate(int year, int month, int date)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                case 11:
                    return checked30(year, month, date);
                case 4:
                case 6:
                case 8:
                case 10:
                case 12: return checked31(year, month, date);
                case 2:
                    return CheckLeap(year, month, date);
                default:
                    return false;
            }

            }


        static void Main(string[] args)
        {
            int date = utilities.GetNumber("Enter date");
            int month = utilities.GetNumber("Enter Month");
            int year = utilities.GetNumber("Enter year");

            if (isValidDate(year, month, date) == true)
            {
                Console.WriteLine("Valid Year");
                return;
            }

            Console.WriteLine("InValid Year");

        }
    }
}