using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork.Practical
{
    class HashSetCollections
    {
        HashSet<Customer> cust = new HashSet<Customer>();
        public void AddCust(Customer cst)
        {
            cust.Add(cst);
        }

        public HashSet<Customer> AllCustomers => cust;
    }
}
