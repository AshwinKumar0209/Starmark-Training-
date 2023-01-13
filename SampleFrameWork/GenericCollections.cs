using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleConApp;

using System.Collections;
using SampleFrameWork.Practical;

namespace SampleFrameWork
{
    class GenericCollections
    {

        //static void Main(string[] args)
        //{
        //    Hashtable Hash = new Hashtable(); //This is NON Generic collection datatype ...
        //    //From next time observe and type Ashwin...

        //    Hash.Add("Ashwin", 9738040397);
        //    Hash.Add("Pooja", "7845896232");

        //    foreach (DictionaryEntry item in Hash)
        //    {
        //        Console.WriteLine("{0}-{1}", item.Key, item.Value);

        //    }

        //}

         static   public void listExample()
        {
            int[] num = { 12, 13, 14, 15, 16, 17, 18, 19 };
            List<int> Collect = new List<int>(num);

            Collect.Add(2);
            Collect.Add(1);
            Collect.Add(3);
            Collect.Add(4);
            Collect.Add(5);
            Collect.Add(6);
            Collect.Add(7);
            Collect.Add(8);

            Console.WriteLine(" The even numbers are");
            foreach (var item in Collect)
            {
                if (item % 2 == 0)
                { Console.Write(item+" ");
                   
                }

            }
            string[] names = { "prajit", "Anagh" };
            List<string> StingCollect = new List<string>(names);
            StingCollect.Add("Ashwin");
            StingCollect.Add("Ashwin");
            StingCollect.Add("Ashwin");
            StingCollect.Add("Ashwin");
            StingCollect.Add("Ashwin");

            foreach (var item in StingCollect)
            {
                Console.WriteLine( item.ToArray() );
            }
        }
      static  public void SetExample()
        {
            HashSet<string> basket = new HashSet<string>();
            basket.Add("Mango");
            basket.Add("orange");
            basket.Add("Apple");
            basket.Add("Chiku");

            Console.WriteLine("The count is "+basket.Count);
            if (basket.Remove("orange"))
            {
                Console.WriteLine("Removed");
            }
            basket.Remove(" ");
            foreach (var item in basket)
            {
                Console.WriteLine(item);

            }
        }
        static Dictionary<string, string> users = new Dictionary<string, string>();

        private static void signUp()
        {
        RETRY:
            var uname = utilities.Prompt("Enter the Username");
            var pwd = utilities.Prompt("Enter the Password");
            if (users.ContainsKey(uname))
            {
                Console.WriteLine("User already Registered");
                goto RETRY;
            }
            users.Add(uname, pwd);
        }

        private static void signIn()
        {
        RETRY:
            var uname = utilities.Prompt("Enter the Username");
            var pwd = utilities.Prompt("Enter the Password");
            if (users.ContainsKey(uname))
            {
                if (users[uname] == pwd)
                {
                    Console.WriteLine("Welcome User!!!");
                }
                else
                {
                    Console.WriteLine("Password is invalid");
                    goto RETRY;
                }
            }
            else
            {
                Console.WriteLine("User does not exist");
                goto RETRY;
            }
        }


        private static void dictionaryExample()
        {
            L:
                var choice = utilities.Prompt("Enter 1 for signUp and 2 for signIn");
                switch (choice)
                {
                    case "1":
                        signUp();
                        break;
                    case "2":
                        signIn();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                    goto L;
                }



            

        }
        static void Main(string[] args)
        {
            //listExample();
            // SetExample();
            //dictionaryExample();
            //SortedListExample();
            //SortingExampleOnCriteria();
            SortingDictionaeyDemo();
        }

        private static void SortingDictionaeyDemo()
        {
            SortedDictionary<string, long> Contacts = new SortedDictionary<string, long>();
            Contacts.Add("Ashwin", 9738040397);
            Contacts.Add("Prajith", 9737794512);
            Contacts.Add("Deepa", 9720154898);
            Contacts.Add("Pooja", 9732457128);
            Contacts.Add("Vaishnavi", 9738040397);
            Contacts.Add("Roja", 9738040397);
            Contacts.Add("Malya", 9738040397);


            Console.WriteLine(Contacts.Count);
            foreach (var item in Contacts)
            {
                Console.WriteLine(item.Key+"-"+item.Value);
            }
        }

        private static void SortingExampleOnCriteria()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { CustId = 100, CustAdd = "Bangalore", CustName = "Ashwin", BillAmt = 500 });
            customers.Add(new Customer { CustId = 200, CustAdd = "Bangalore", CustName = "Prajit", BillAmt = 600 });
            customers.Add(new Customer { CustId = 012, CustAdd = "Bangalore", CustName = "Pavan", BillAmt = 100 });
            customers.Add(new Customer { CustId = 11, CustAdd = "Bangalore", CustName = "Deepu", BillAmt = 250 });
            Console.WriteLine("Enter the Creteria to sort");
            Array values = Enum.GetValues(typeof(Criteria));
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
            Criteria selected = (Criteria)Enum.Parse(typeof(Criteria), Console.ReadLine());
            customers.Sort(new CustomerComparer(selected));
            foreach (var item in customers)
            {
                Console.WriteLine(item);

            }
        }

        private static void SortedListExample()
        {
            SortedList<string, long> cont = new SortedList<string, long>();
            cont.Add("Zabi us Zuhail", 8050364123);
            cont.Add("Nabi us Zuhail", 8050364123);
            cont.Add("abhi us Zuhail", 8050364123);
            cont.Add("Mabi us Zuhail", 8050364123);
            foreach (var item in cont)
            {
                Console.WriteLine(item.Key+"-"+item.Value);
            }
        }
    } 
}
