using SampleConApp;
using SampleFrameWork.Practical;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleFrameWork
{
    
   class Assignment_Serialization
    {
       static   List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Press 1 To Add Customer------------------------------");
            Console.WriteLine("Press 2 To View Customer-----------------------------");
            Console.WriteLine("Press 3 To Delete Customer---------------------------");
            Console.WriteLine("Press 4 To Insert Customer---------------------------");
            Console.WriteLine("-----------------------------------------------------");
            RETRY:
            var choice = utilities.Prompt("Enter choice");

            switch (choice)
            {
                case "1":
                    AddCustomer();
                    goto RETRY;
                case "2":
                    ViewCustomer();
                    goto RETRY;
                case "3":
                    DeleteCusTByID();
                    goto RETRY;
                case "4":
                    InsertById();
                    goto RETRY;
                default:
                    Console.WriteLine("Wrong Choice");
                    goto RETRY;
            }
            


        }

        private static void InsertById()
        {
            RETRYID:
            int Newid = utilities.GetNumber("Enter Id");
            List<Customer> Newcst = Deserialize();
            for (int i = 0; i < Newcst.Count; i++)
            {
                if (Newcst[i].CustId == Newid)
                {
                    Newcst[i].CustName = utilities.Prompt("Enter Name");
                    Newcst[i].CustAdd = utilities.Prompt("Enter Address");
                    Newcst[i].BillAmt = utilities.GetNumber("Enter Bill");
                }
                else
                {
                    Console.WriteLine("ID not Found");
                   goto RETRYID;
                }
            }

            FileStream fs = new FileStream("cust.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, Newcst);
            fs.Close();

        }

        private static void DeleteCusTByID()
        {
            RETRYDELID:
            int Newid = utilities.GetNumber("Enter Id");
            List<Customer> Newcst = Deserialize();
            for (int i = 0; i < Newcst.Count; i++)
            {if(Newcst[i].CustId==Newid)
                {
                    Newcst.Remove(Newcst[i]);
                }
                else
                {
                    Console.WriteLine("ID Not Found");
                    goto RETRYDELID;
                }
            }


            FileStream fs = new FileStream("cust.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, Newcst);
            fs.Close();

            //ViewCustomer();

            //List<Customer> Deserializecustomers = null;
            //FileStream fm = new FileStream("cust.xml", FileMode.Open, FileAccess.Read);
            //XmlSerializer formatter1 = new XmlSerializer(typeof(List<Customer>));
            //Deserializecustomers = formatter1.Deserialize(fm) as List<Customer>;
            //fm.Close();

            //foreach (var item in Deserializecustomers)
            //{
            //    Console.WriteLine(item.ToString()); 
            //}
        }


        private static List<Customer> Deserialize()
        {
            List<Customer> customers = null;
            FileStream fm = new FileStream("cust.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            customers = formatter.Deserialize(fm) as List<Customer>;
            fm.Close();
            return customers;
        }
        private static void ViewCustomer()
        {
            List<Customer> customers = null;
            FileStream fm = new FileStream("cust.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            customers = formatter.Deserialize(fm) as List<Customer>;
            fm.Close();

            foreach (var item in customers)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void AddCustomer()
        {
            Customer cust = new Customer();
            cust.CustId = utilities.GetNumber("Enter ID ");
            cust.CustName = utilities.Prompt("Enter Name");
            cust.CustAdd = utilities.Prompt("Enter Address");
            cust.BillAmt = utilities.GetNumber("Enter Bill");
            customers.Add(cust);

            FileStream fs = new FileStream("cust.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, customers);
            fs.Close();
        }
    }
}
