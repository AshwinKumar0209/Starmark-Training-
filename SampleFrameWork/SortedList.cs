using SampleFrameWork.Practical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class SortedList
    {
        static void Main(string[] args)
        {


            sortingExampleOnCus();


                }

        private static void sortingExampleOnCus()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { CustId = 1, CustAdd = "Bangalore", CustName = "Ashwin", BillAmt = 5600 });
            customers.Add(new Customer { CustId = 1, CustAdd = "Bangalore", CustName = "Prajit", BillAmt = 5600 });
            customers.Add(new Customer { CustId = 1, CustAdd = "Bangalore", CustName = "Pavan", BillAmt = 5600 });
            customers.Add(new Customer { CustId = 1, CustAdd = "Bangalore", CustName = "Deepu", BillAmt = 5600 });

            customers.Sort();
            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
