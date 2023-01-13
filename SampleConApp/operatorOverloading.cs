using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class EmployeeOverLoading {

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }

        public static EmployeeOverLoading operator + (EmployeeOverLoading emp, int amount)
        {
           emp.EmpSalary += amount;
            return emp;
        }
        public static EmployeeOverLoading operator -(EmployeeOverLoading emp, int amount)
        {
            emp.EmpSalary -= amount;
            return emp;
        }
        public static bool operator < (EmployeeOverLoading emp ,int amount)
        {
            return emp.EmpSalary < amount; 
        }
        public static bool operator >(EmployeeOverLoading emp, int amount)
        {
            return emp.EmpSalary > amount;
        }
        public static bool operator == (EmployeeOverLoading emp, EmployeeOverLoading emp1)
        {
            return emp.EmpSalary == emp1.EmpSalary;
        }
        public static bool operator != (EmployeeOverLoading emp, EmployeeOverLoading emp1)
        {
            return emp.EmpSalary != emp1.EmpSalary;
        }
    }

    class operatorOverloading
    {
        static void Main(string[] args)
        {
            int amount = utilities.GetNumber("enter Salary");
            EmployeeOverLoading emp = new EmployeeOverLoading { EmpId = 3306, EmpName = "Ashwin", EmpSalary = 28000 };
            EmployeeOverLoading emp1 = new EmployeeOverLoading { EmpId = 3307, EmpName = "Ashwin", EmpSalary = 29000 };

            emp += amount;
            Console.WriteLine("The current Salary is " + emp.EmpSalary);
            emp -= 500;
            Console.WriteLine("The current Salary is "+ emp.EmpSalary);
            Console.WriteLine(emp>amount);
            Console.WriteLine(emp < amount);
            Console.WriteLine(emp == emp1);
            Console.WriteLine(emp != emp1);

        }
    }
}
