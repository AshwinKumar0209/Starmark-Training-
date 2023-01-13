using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SampleFrameWork.Practical
{
    class ListCollection : IDataComponent
    {
        public ListCollection()
        {
            Console.WriteLine("List is being used");
        }

        List<Customer> customers = new List<Customer>();
        public void AddNewCustomer(Customer cst)
        {
            customers.Add(cst);
        }

        public void DeleteCustomer(int id)
        {
            foreach (var cst in customers )
            {
                if (cst.CustId == id)
                {
                    customers.Remove(cst);
                    return;
                }
            }
            throw new CustomerException("Customer not found to Delete");
        }

        public Customer[] GetAllCustomers()
        {
           return customers.ToArray();
        }

        public void UpdateCustomer(Customer cst)
        {
            foreach (var cs in customers)
            {
                if (cs.CustId == cst.CustId)
                {
                    cst.Copy(cst);
                    return;
                }
            }
            throw new CustomerException("Customer not found to Delete");

        }
    }
}
