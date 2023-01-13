using DataLayer;
using System;
using SampleFrameworksApp.Practical;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleFrameWork.Practical;
using Utilities;
using SampleConApp;

namespace SampleFrameworksApp.Practical
{
    class MainUI
    {
        static IDataComponent component = null;
        static MainUI()
        {
            //Console.WriteLine("Enter the Name of the Component as:List or ArrayList");
            //component = CustomerFactory.GetComponent(Console.ReadLine());
        }
        //static IDataComponent component = new CustomerDatabase();
        static Dictionary<string, string> Collections = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            component.AddNewCustomer(new Customer { CustId = 111, CustName = "Ramesh Adiga", CustAdd = "Kundapur", BillAmt = 5600 });

            component.UpdateCustomer(new Customer { CustId = 111, CustName = "Ramesh Adiga", CustAdd = "Udupi", BillAmt = 5600 });


            var data = component.GetAllCustomers();
            foreach (var customer in data)
                Console.WriteLine(((Customer)customer).CustName);
            component.DeleteCustomer(111);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(); 
            HashSetCollections collection = new HashSetCollections();
            collection.AddCust(new Customer { CustId = 111, CustName = "Ashwin", CustAdd = "Bangalore", BillAmt = 28000 });
            collection.AddCust(new Customer { CustId = 111, CustName = "prajit", CustAdd = "Bangalore", BillAmt = 28000 });
            collection.AddCust(new Customer { CustId = 111, CustName = "Ashwin", CustAdd = "Bangalore", BillAmt = 28000 });
            collection.AddCust(new Customer { CustId = 113, CustName = "Ashwin", CustAdd = "Bangalore", BillAmt = 28000 });
            collection.AddCust(new Customer { CustId = 112, CustName = "Ashwin", CustAdd = "Bangalore", BillAmt = 28000 });

            Console.WriteLine("the total count is " + collection.AllCustomers.Count);
            foreach (var customer in collection.AllCustomers)
            {
                Console.WriteLine(customer);
            }


        }
    }
}