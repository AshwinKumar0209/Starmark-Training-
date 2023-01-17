using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ADO_Week3
{
    class utilities
    {
        internal static string Prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        internal static int GetNumber(string question)
        {
            return int.Parse(Prompt(question));
        }
    }
    static class Database
    {
        const string Connection = "Data Source=192.168.171.36;Initial Catalog=3306;Integrated Security=True";
        const string SQLQUERY = "Select * from Employee";
        public static DataTable GetAllRecords()
        {
            SqlConnection sqlCon = new SqlConnection(Connection);

            SqlCommand sqlcommand = new SqlCommand(SQLQUERY, sqlCon);

            try
            {
                sqlCon.Open();
                var reader = sqlcommand.ExecuteReader();
                DataTable table = new DataTable("EmpRecords");
                table.Load(reader);
                return table;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open)
                    sqlCon.Close();
            }

        }

    }
  

    class SqlConnectionDemo
    {
        const string Connection = "Data Source=192.168.171.36;Initial Catalog=3306;Integrated Security=True";
        const string SQLQUERY = "SELECT * FROM Employee WHERE EmpName LIKE '%THALAPATHY%'";
        static void Main(string[] args)
        {
            //ReadingData();
            // DisplayTable();
             string name = utilities.Prompt("ENter Name");
            string Address = utilities.Prompt("Enter Address");
            int Id = utilities.GetNumber("Enter ID");
            int Salary = utilities.GetNumber("Enter Salary");
            //DisplayName(name);
            //DiaplayWithParameter(name);
            // AddRecord(name,Address,Id,Salary);
            // addNewRecordFromInput();
            StoredProc(name,Address,Salary,Id);
        }

        private static void StoredProc(string name,string address, int salary, int DeptId)
        {
            int empId = 0;
            SqlCommand cmd = new SqlCommand(StoredFind, new SqlConnection(Connection));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpName", name);
            cmd.Parameters.AddWithValue("@EmpAddress", address);
            cmd.Parameters.AddWithValue("@EmpSalary", salary);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@EmpId", empId);
            cmd.Parameters.AddWithValue("@Manag", 9);
            cmd.Parameters[4].Direction = ParameterDirection.Output;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                empId = Convert.ToInt32(cmd.Parameters[4].Value);
                Console.WriteLine(empId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpName"]}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {
                cmd.Connection.Close();
            }

        }

        const string StoredFind = "InsertEmployee";
        private static void addNewRecordFromInput()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Department1", new SqlConnection(Connection));
            try
            {
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["DeptName"]}");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                    cmd.Connection.Close();
            }
            string Choice = utilities.Prompt("Enter Department");
            PrintDeptNum(Choice);


        }

        private static void PrintDeptNum(string choice)
        {
            SqlCommand cmd = new SqlCommand($"SELECT DeptId from Department1 WHERE DeptName LIKE %{choice}%",new SqlConnection(Connection));
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        private static void AddRecord(string name, string address, int id, int salary)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee VALUES(@name,@Address,@Salary,@DeptId,@Manag)", new SqlConnection(Connection));
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Salary", salary);
            cmd.Parameters.AddWithValue("@DeptId", 12);
            cmd.Parameters.AddWithValue("@Manag", 3);

            try
            {
                cmd.Connection.Open();
                var rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                {
                    throw new Exception("Failed to Add Record to the table");
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

          
        }

        private static void DiaplayWithParameter(string name)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE  EmpNAme=@name", new SqlConnection(Connection));
            try
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"EmpID: {reader[0]} EmpName: {reader[1]} \t EmpAddress: {reader[2]} \t EmpSalary: {reader[3]}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally {
                cmd.Connection.Close();
            }

        }

        private static void DisplayName(string name)
        {
            SqlConnection sqlCon = new SqlConnection(Connection);

            string SQLQUERY = $"SELECT * FROM Employee WHERE EmpName LIKE '%{name}%'";
            SqlCommand sqlcommand = new SqlCommand(SQLQUERY, sqlCon);
            try
            {
                sqlCon.Open();
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpName"]}from {reader["EmpId"]}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        private static void DisplayTable()
        {

            try
            {
                var table = Database.GetAllRecords();

                foreach (DataRow item in table.Rows)
                {
                    Console.WriteLine($"EmpName: {item[1]} \n EmpAddress:{item[2]}\n EmpSalary: {item[3]}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
          
        }

        private static void ReadingData()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = Connection;

            SqlCommand sqlcommand = sqlCon.CreateCommand();
            sqlcommand.CommandText = SQLQUERY;



            try
            {
                sqlCon.Open();
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpName"]}from {reader["EmpId"]}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open)
                    sqlCon.Close();
            }
        }
    }
}
