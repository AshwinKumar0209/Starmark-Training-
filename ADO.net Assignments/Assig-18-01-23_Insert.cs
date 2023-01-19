using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using SampleConApp;
using System.Data;
using System.IO;


namespace ADO_Week3
{

    class EmployeeListDb
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public long EmpSalary { get; set; }
        public int DeptID { get; set; }
        public int Manag { get; set; }

    }


    class Assig_18_01_23_Insert
    {
        static string Connection = "Data Source=192.168.171.36;Initial Catalog=3306;Integrated Security=True";
            /*ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;*/
        static void Main(string[] args)
        {
            // InsertData();
            // DeleteData();
            // InnerJoin();
           // DataToList();
           // FindingNameDS();
            // InsertDataStoredProcedure();
          // ReadingCSV();
        }

        private static void ReadingCSV()
        {
            string filename = "../../Customers.csv";
            var Lines = File.ReadAllLines(filename);
            List<String> str = new List<string>();
            foreach (var item in Lines)
            {
                var Line1 = item.Split(',');
                str.Add(Line1[0]);
                
               
            }
            foreach (var item in str)
            {
                Console.WriteLine(item);
            } 



        }

        private static void InsertDataStoredProcedure()
        {
            const string query = "InsertEmployee";

            SqlCommand cmd = new SqlCommand(query, new SqlConnection(Connection));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Empname", utilities.Prompt("Enter Name"));
            cmd.Parameters.AddWithValue("@EmpAddress", utilities.Prompt("Enter Address"));
            cmd.Parameters.AddWithValue("@EmpSalary", utilities.GetNumber("Enter Salary"));
            cmd.Parameters.AddWithValue("@DeptId", utilities.GetNumber("Enter DeptID"));
            cmd.Parameters.AddWithValue("@EmpID", utilities.GetNumber("Enter EmpID"));
            cmd.Parameters.AddWithValue("@Manag", utilities.GetNumber("Enter Manag"));
            cmd.Parameters[4].Direction = ParameterDirection.Output;

            try
            {
                cmd.Connection.Open();
                var affectedRow = cmd.ExecuteNonQuery();
                Console.WriteLine(affectedRow);
                int empId =(int) cmd.Parameters[4].Value;
                Console.WriteLine(empId);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally {
                cmd.Connection.Close();
            }
        }

        private static void FindingNameDS()
        {
            string name = utilities.Prompt("Enter Name to find");
            FindingDS(name);
        }

        private static void FindingDS(string name)
        {
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM Employee", Connection);
            DataSet DupDB = new DataSet("Employee DEtails");
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(cmd);
            cmd.Fill(DupDB);
            DupDB.Tables[0].TableName = "EmpList";

            foreach (DataRow item in DupDB.Tables[0].Rows)
            {
                if (item[1].ToString() == name)
                {
                    Console.WriteLine($"EmpID: {item[0]}");
                }
            }

        }

        private static void DataToList()
        {
            SqlCommand cmd = new SqlCommand("Select * From Employee", new SqlConnection(Connection));
            List<EmployeeListDb> employees = new List<EmployeeListDb>();
            try
            {
                cmd.Connection.Open();
              
                var reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    EmployeeListDb emp = new EmployeeListDb();
                    emp.EmpId = (int)reader["EmpId"];

                    emp.EmpName = reader["EmpName"].ToString();

                    emp.EmpAddress = reader["EmpAddress"].ToString();
                    emp.EmpSalary = 100;//In our DB the values are too huge 

                    emp.DeptID = 1001;// IN out DB some of them are null values so typecast error occurs 
                    emp.Manag = 133; //Same as above
                    employees.Add(emp);
                } 
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally {
                cmd.Connection.Close();
            }
            foreach (var item in employees)
            {
                Console.WriteLine($"EmpName:{item.EmpId} EmpAddress: {item.EmpAddress}");
            }

        }

        private static void InnerJoin()
        {
            SqlCommand cmd = new SqlCommand("SELECT EmpName,Department1.DeptName FROM Department1 Inner Join Employee ON Department1.DeptID=Employee.DeptID", new SqlConnection(Connection));
            try
            {
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"EmpName : {reader["EmpName"]}\n DeptName:{reader["DeptName"]}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally {
                cmd.Connection.Close();

            }
        }

        private static void DeleteData()
        {
            int id = utilities.GetNumber("Enter ID to Delete");
            DeleteEmployee(id);
        }

        private static void DeleteEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand($"DELETE FROM EMployee WHERE EmpId='{id}'",new SqlConnection(Connection));
            try
            {
                cmd.Connection.Open();
                var reader = cmd.ExecuteNonQuery();
                if (reader != 1)
                {
                    Console.WriteLine("Deletion Failed");
                }
            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.Message);
            }
        }

        private static void InsertData()
        {
            string name = utilities.Prompt("Enter Name");
            string address = utilities.Prompt("Enter Address");
            int salary = utilities.GetNumber("Enter Salary");
            int deptId = utilities.GetNumber("Enter DeptID");
            int manag = utilities.GetNumber("Enter Manager ID");
            InsertEmployee(name, address, salary, deptId, manag);
        }

        private static void InsertEmployee(string name,string address,int salary,int deptId,int manag)
        {
           
             string Query = $"INSERT INTO Employee (EmpName,EmpAddress,EmpSalary,DeptID,Manag) VAlUES('{name}','{address}','{salary}','{deptId}','{manag}')";
            SqlCommand cmd = new SqlCommand(Query, new SqlConnection(Connection));
            try
            {
                cmd.Connection.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                {
                    Console.WriteLine("Insertion Failed");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally {
                cmd.Connection.Close();

            }
        }
    }
}
