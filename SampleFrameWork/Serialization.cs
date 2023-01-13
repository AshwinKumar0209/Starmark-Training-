using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using SampleConApp;
using System.Runtime.Serialization.Formatters.Soap;

namespace SampleFrameWork
{   
    [Serializable]
   public class Employee {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAdd { get; set; }

        public override string ToString()
        {
            return $"{EmpName} from {EmpAdd}";
        }

    }
   public class Serialization
    {
        static void Main(string[] args)
        {
            //SerialExample();
            //DeserialExample();

            var choice = utilities.GetNumber("Enter 1 S and 2 D");
            //if (choice == 1) {
            //    XmlSerialize();
            //}
            //else 
            //    XmlDeserialize();
            if(choice==1)
                SoapDeserialExample();
            else
                SoapXmlSerialize();
            

        }

        private static void XmlDeserialize()
        {
            Employee emp = null;
            FileStream fs = new FileStream("Emp1.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer formatter = new XmlSerializer(typeof(Employee));
            emp = formatter.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp);
        }
        private static void SoapXmlSerialize()
        {
            Employee emp = new Employee();
            emp.EmpName = utilities.Prompt("Enter Name");
            emp.EmpId = utilities.GetNumber("Enter Id");
            emp.EmpAdd = utilities.Prompt("Enter Address");
            FileStream fs = new FileStream("EmpSoap.xml", FileMode.OpenOrCreate, FileAccess.Write);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(fs, emp);
        }
        private static void SoapDeserialExample()
        {
            Employee emp = null;
            FileStream fm = new FileStream("EmpSoap.xml", FileMode.Open, FileAccess.Read);
            SoapFormatter formatter = new SoapFormatter();
            emp = formatter.Deserialize(fm) as Employee;
            fm.Close();
            Console.WriteLine(emp);
        }
        private static void XmlSerialize()
        {
            Employee emp = new Employee { EmpAdd = "Tamil Nadu", EmpName = "Thalapathy Vijay", EmpId = 21071978 };
            FileStream fs = new FileStream("Emp1.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(Employee));
            formatter.Serialize(fs, emp);
        }

        private static void DeserialExample()
        {
            Employee emp = null;
            FileStream fm = new FileStream("Emp.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            emp = formatter.Deserialize(fm) as Employee;
            fm.Close();
            Console.WriteLine(emp);
        }

        private static void SerialExample()
        {
            Employee emp = new Employee
            {
                EmpId = 3306,
                EmpName = "Ashwin",
                EmpAdd = "Bangalore"
            };

            FileStream fm = new FileStream("Emp.bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fm, emp);
            fm.Close();
        }
    }
}
