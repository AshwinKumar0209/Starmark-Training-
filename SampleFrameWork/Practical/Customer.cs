using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork.Practical
{
  

  public  class Customer : IComparable<Customer>
    {
        public int CustId { get; set; }
        public string CustName { get; set; }

        public string CustAdd { get; set; }

        public int BillAmt { get; set; }

        public void Copy(Customer cst)
        {
            CustId = cst.CustId;
            CustName = cst.CustName;
            CustAdd = cst.CustAdd;
            BillAmt = cst.BillAmt;
        }

        public override int GetHashCode()
        {
            return CustId.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(obj is Customer)
            {
               var unbox = obj as Customer;
                if(CustId==unbox.CustId && CustName==unbox.CustName && CustAdd==unbox.CustAdd && BillAmt == unbox.BillAmt)
                {
                    return true;
                }
            }return false;
        }

        public override string ToString()
        {
            //return $"Name:{CustName} with id:{CustId} from {CustAdd} with Bill Amount {BillAmt}";
            return $"{CustId},{CustName},{CustAdd},{BillAmt}\n";
        }

        public int CompareTo(Customer obj)
        {
            return CustName.CompareTo(obj.CustName);
        }

        
    }
    enum Criteria { ID,Name,Address,Bill}
    class CustomerComparer : IComparer<Customer>
    {
        private Criteria criteria;
        public CustomerComparer(Criteria criteria)
        {
            this.criteria = criteria;
        }
public int Compare(Customer x, Customer y)
        {
            switch (criteria)
            {
                case Criteria.ID:
                    return x.CustId.CompareTo(y.CustId);
                case Criteria.Name:
                    return x.CustName.CompareTo(y.CustName);
                case Criteria.Address:
                    return x.CustAdd.CompareTo(y.CustAdd);
                case Criteria.Bill:
                    return x.BillAmt.CompareTo(y.BillAmt);

            }
            return 0;
        }
    }
}
