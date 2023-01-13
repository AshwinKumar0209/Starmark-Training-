using SampleFrameWork.Practical;
using System;
using System.Collections;
namespace DataLayer
{
    interface IDataComponent
    {
        void AddNewCustomer(Customer cst);
        void UpdateCustomer(Customer cst);
        Customer[] GetAllCustomers();
        void DeleteCustomer(int id);
    }

    class CustomerDatabase : IDataComponent
    {
        private ArrayList _listOfCustomers = new ArrayList();//UR Array is replaced by ArrayList. 
        public void AddNewCustomer(Customer cst)
        {
            _listOfCustomers.Add(cst);
            Console.WriteLine("Added Successfully");
        }

        public void DeleteCustomer(int id)
        {

            foreach (var cs in _listOfCustomers)
            {
                var unBox = cs as Customer;
                if (unBox.CustId == id)
                {
                    _listOfCustomers.Remove(unBox);
                    return;
                }

            }
        }

        public Customer[] GetAllCustomers()
        {

            Customer[] array = new Customer[_listOfCustomers.Count];
            for (int i = 0; i < _listOfCustomers.Count; i++)
            {
                if (_listOfCustomers[i] is Customer)
                    array[i] = _listOfCustomers[i] as Customer;//UNBOXING...
            }
            return array;



        }

        public void UpdateCustomer(Customer cst)
        {


            foreach (var cs in _listOfCustomers)
            {
                if (cs is Customer)
                {
                    var unBox = cs as Customer;
                    if (unBox.CustId == cst.CustId)
                    {
                        unBox.CustName = cst.CustName;
                        unBox.CustAdd = cst.CustAdd;
                        unBox.BillAmt = cst.BillAmt;
                        return;

                    }



                }
                //throw new Exception("index Not Found To Update");
            }
        }
    }


    class Collections {

        static void Main(string[] args)
        {
            Hashtable Hash = new Hashtable();

            Hash.Add("Ashwin", 9738040397);
            Hash.Add("Pooja", 7845896232);

            foreach (DictionaryEntry item in Hash)
            {
                Console.WriteLine("{0-{1}}",item.Key,item.Value);

            }

        }

    }


}
