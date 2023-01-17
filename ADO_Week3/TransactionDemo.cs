using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Week3
{
    class TransactionDemo
    {
        static readonly string Connection = "Data Source=192.168.171.36;Initial Catalog=3306;Integrated Security=True";
        private static void addEmployee(string name,string address,int salary,string deptName)
        {
            SqlTransaction transaction = null;
            SqlConnection con = new SqlConnection(Connection);
            string cmdGetDeptId = $"SELECT dbo.GetDept('{deptName}') as DeptId";
            string cmdInsertDept = "InsertDept";
            int deptId = 0;
            try
            {
                con.Open();
                transaction = con.BeginTransaction();
                SqlCommand cmd1 = new SqlCommand(cmdGetDeptId, con, transaction);
                deptId = (int)cmd1.ExecuteScalar();
                if (deptId == 0)
                {
                    SqlCommand cmd2 = new SqlCommand(cmdInsertDept, con, transaction);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@deptName", deptName);
                    cmd2.Parameters.AddWithValue("@deptId", 0);
                    cmd2.Parameters[1].Direction = System.Data.ParameterDirection.Output;
                    cmd2.ExecuteNonQuery();
                    deptId = (int)cmd2.Parameters[1].Value;
                }

                SqlCommand cmd3 = new SqlCommand("INSERTEMPLOYEE", con, transaction);
                cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@empName", name);
                cmd3.Parameters.AddWithValue("@empaddress", address);
                cmd3.Parameters.AddWithValue("@empSalary", salary);
                cmd3.Parameters.AddWithValue("@deptId", deptId);
                cmd3.Parameters.AddWithValue("@empId", 0);
                cmd3.Parameters.AddWithValue("@Manag", 5);
                cmd3.Parameters[4].Direction = System.Data.ParameterDirection.Output;
                cmd3.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("The Employee has been added to the database with ID"+cmd3.Parameters[4].Value);

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw ex;
            }
        }
        static void Main(string[] args)
        {
            addEmployee("Nivedhitha", "Punjab", 34221, "PreSales");
        }
    }
}
