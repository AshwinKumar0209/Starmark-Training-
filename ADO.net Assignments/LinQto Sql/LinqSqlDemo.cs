using SampleConApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADO_Week3.LinQto_Sql
{
    class LinqSqlDemo
    {

        static void Main(string[] args)
        {
            // GetAllEmployees();
            //  UpdateEmployee();
            //InsertEmployee();
            //DeleteRecord();
            UIRun();

        }

        private static void UIRun()
        {
            RETRY:
            Console.Clear();
            Console.WriteLine("Enter 1 in Get All employess");
            Console.WriteLine("Enter 2 to Add Employee");
            Console.WriteLine("Enter 3 to Update Employee");
            Console.WriteLine("Enter 4 to Delete Employee");
            Console.WriteLine("Enter 5 to Exit");
            int choice = 0;
            try
            {
                choice = utilities.GetNumber("Enter Choice");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            switch (choice)
            {
                case 1:
                    GetAllEmployees();
                    Thread.Sleep(4000);
                    goto RETRY;

                case 2:
                    InsertEmployee();
                        goto RETRY;
                case 3:
                    UpdateEmployee();
                    goto RETRY;
                case 4:
                    DeleteRecord();
                    goto RETRY;
                case 5:
                    Console.WriteLine("Thanks for surfing");
                    break;
                default:
                        Console.WriteLine("Invalid Choice");
                    Thread.Sleep(1000);
                        goto RETRY;
            }
        }

        private static void DeleteRecord()
        {
            var context = new LinqSqlDemoDataContext();
            int id = utilities.GetNumber("Enter ID");
            var rec = (from emp in context.Employees
                      where emp.EmpId == id
                      select emp).FirstOrDefault();
            context.Employees.DeleteOnSubmit(rec);
            context.SubmitChanges();

        }

        private static void InsertEmployee()
        {
            var context = new LinqSqlDemoDataContext();
            var rec = new Employee
            {
                DeptID = 3,
                EmpAddress = "Bangalore",
                EmpName = "Bharani",
                EmpSalary = 40000
            };
            context.Employees.InsertOnSubmit(rec);
            context.SubmitChanges();
        }

        private static void UpdateEmployee()
        {
            var context = new LinqSqlDemoDataContext();
            int id = utilities.GetNumber("Enter ID");
            var empdetails = (from emp in context.Employees
                              where emp.EmpId == id
                              select emp).FirstOrDefault();
            empdetails.EmpName = utilities.Prompt("Enter Name");
            empdetails.EmpAddress = utilities.Prompt("Enter Address");
            empdetails.EmpSalary = utilities.GetNumber("Enter Salary");
            empdetails.DeptID = utilities.GetNumber("Enter Department ID");
            context.SubmitChanges();

            
        }

        private static void GetAllEmployees()
        {
            var context = new LinqSqlDemoDataContext();
            var EmpDetails = from emp in context.Employees
                             select emp;

            foreach (var item in EmpDetails)
            {
                Console.WriteLine(item.EmpName + "Works in " + item.Department1.DeptName);
            }
        }
    }
}
