using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    struct Employee { 
        public int Empid { get; set; }
    public String EmpName { get; set; }
    public string EmpAddress { get; set; }
    public double EmpSalart { get; set; }
        public String GetAllDetails()
        {
            return $"The name is {EmpName} with ID No: {Empid} from {EmpAddress} is Earning {EmpSalart}";
        }
    }
    class EX_04Struct   //THEY ARE LIGHT CLASSES <THEY DONT HAVE ANY OOPS! PROPETIES
    {
        static void Main()
        {
            Console.WriteLine("WELCOME TO STRUCTURES");
            Employee obj = new Employee { Empid = 3306, EmpName = "Ashwin Vijay", EmpAddress = "Bangalore", EmpSalart = 29000 };//THIS DEATURE IS CALLED OBJECT INITIALIZATION AVAILABLE FROM VS  v4.0

            Console.WriteLine(obj.GetAllDetails());

        }
    }
}
