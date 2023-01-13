using SampleFrameWork.Practical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace SampleFrameWork
{
    class XMLFile
    {
        const string filename = "../../Customers.csv";
        static Customer[] GetCustomers(string fileName)
        {
            List<Customer> AllCustomers = new List<Customer>();
            var AllLines = File.ReadAllLines(filename);
            foreach (var lines in AllLines)
            {
                var words = lines.Split(',');//single quotes because it is a single character
                Customer cst = new Customer();
                cst.CustName = words[1];
                cst.CustId = int.Parse(words[0]);
                cst.CustAdd = words[2];
                cst.BillAmt = int.Parse(words[3]);
                AllCustomers.Add(cst);
            }
            return AllCustomers.ToArray();
        }
        static void Main(string[] args)
        {
            var data = GetCustomers(filename);
            DataTable table = new DataTable("Customer");
            table.Columns.Add("CustomerId", typeof(int));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("CustomerAddress", typeof(string));
            table.Columns.Add("BillAmount", typeof(int));
            foreach (var cst in data)
            {
                DataRow row = table.NewRow();
                row[0] = cst.CustId;
                row[1] = cst.CustName;
                row[2] = cst.CustAdd;
                row[3] = cst.BillAmt;
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            DataSet ds = new DataSet("Customers");
            ds.Tables.Add(table);
            ds.WriteXml("../../Customers.xml");
            Console.WriteLine(ds.GetXml());
 
        }

    }
}
