using DataLayer;
using SampleFrameWork.Practical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    static class CustomerFactory
    {
       
        
            public static IDataComponent GetComponent(string type)
            {
                IDataComponent component = null;
                switch (type.ToLower())
                {
                    case "list": return new ListCollection();
                    case "arraylist": return new CustomerDatabase();
                    default:
                        throw new CustomerException("This type is not supported by us");
                }
            }
        

    }
}
