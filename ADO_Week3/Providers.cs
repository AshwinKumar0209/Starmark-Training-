using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Week3
{
   
    class Patient {
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public string Sex { get; set; }
        public string Treatment { get; set; }
        public int ProviderID { get; set; }

    }
    class ProviderMain {
        public string ProviderName { get; set; }
        public string ProviderSpecial { get; set; }
    }
    class Providers : Provider
    {

        const string Connection = "Data Source=192.168.171.36;Initial Catalog = 3306; Integrated Security = True";
        public void AddPatient(Patient patient)
        {
            const string AddPat = "INSERT INTO Patient VALUES(@PatientName,@Age,@BloodGroup,@Sex,@Treatment,@ProviderID)";
            SqlCommand cmd = new SqlCommand(AddPat, new SqlConnection( Connection));

            cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
            cmd.Parameters.AddWithValue("@Sex", patient.Sex);
            cmd.Parameters.AddWithValue("@Age", patient.Age);
            cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);
            cmd.Parameters.AddWithValue("@Treatment", patient.Treatment);
            cmd.Parameters.AddWithValue("@ProviderID", patient.ProviderID);
            try
            {
                cmd.Connection.Open();
                var RowsAffected = cmd.ExecuteNonQuery();
                if(RowsAffected!=1)
                    Console.WriteLine("Failed to add into table");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }finally
            {
                cmd.Connection.Close();
            }

            
            
        }

        public void AddProviders(ProviderMain providermain)
        {
            const string AddProvider = "INSERT INTO PROVIDERS VALUES(@ProviderName,@ProviderSpecial)";
            SqlCommand cmd = new SqlCommand(AddProvider, new SqlConnection(Connection));
            cmd.Parameters.AddWithValue("@ProviderName", providermain.ProviderName);
            cmd.Parameters.AddWithValue("@ProviderSpecial", providermain.ProviderSpecial);

            try
            {
                cmd.Connection.Open();
                var RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected != 1)
                    Console.WriteLine("Failed to add into table");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }finally
            {
                cmd.Connection.Close();
            }

        }

        public void DeletePatient(int id)
        {
             string DeleteProvider = $"DELETE FROM Patient WHERE PatientID={id}";
            SqlCommand cmd = new SqlCommand(DeleteProvider, new SqlConnection(Connection));

            try
            {
                cmd.Connection.Open();
                var RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected != 1)
                    Console.WriteLine("Failed to Delete table");

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

        public void GetAllPatients()
        {
            string AllPatients = "SELECT * FROM Patient";
            SqlCommand cmd = new SqlCommand(AllPatients, new SqlConnection(Connection));
            try
            {
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
            
              while(reader.Read())
                {
                    Console.WriteLine($"PatientName: {reader[1]} \n Patient ID :{reader[0]}\n  Patient Age: {reader[2]}\n BloodGroup: {reader[3]}\n Treatment : {reader[4]}\n ProviderID:{reader[5]}");
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

        public void UpdatePatient(int id)
        {
            string updatePatient = $"UPDATE Patient SET PatientName=@patientName,Age=@age,BloodGroup=@bloodGroup,Sex=@sex,Treatment=@treatment,ProviderID=@providerid WHERE PatientID={id}";
            SqlCommand cmd = new SqlCommand(updatePatient, new SqlConnection(Connection));
            cmd.Parameters.AddWithValue("@patientName", utilities.Prompt("Enter New Patient name"));
            cmd.Parameters.AddWithValue("@age", utilities.Prompt("Enter New Patient age"));
            cmd.Parameters.AddWithValue("@bloodGroup", utilities.Prompt("Enter New Patient Blood Group"));
            cmd.Parameters.AddWithValue("@sex", utilities.Prompt("Enter New Patient sex"));
            cmd.Parameters.AddWithValue("@treatment", utilities.Prompt("Enter Diease type"));
            cmd.Parameters.AddWithValue("@providerid", utilities.Prompt("Enter providerID"));
            try
            {
                cmd.Connection.Open();
                var RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected != 1)
                    Console.WriteLine("Failed to update into table");

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
    }
    class Working {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO STARMARK HOSPITAL CARE");
        RETRY:
            Console.WriteLine("Press 1 To ADD Patient-------------");
            Console.WriteLine("Press 2 To ADD Providers-----------");
            Console.WriteLine("Press 3 To Delte Patient by Id------");
            Console.WriteLine("Press 4 To Update Patient by Id-----");
            Console.WriteLine("Press 5 To Get All Patient----------");
            Console.WriteLine("Press 6 To Exit---------------------");


            int choice = utilities.GetNumber("Choice");
            Providers providers = new Providers();
            switch (choice)
            {
                case 1:
                    Patient patient = new Patient();
                    patient.PatientName = utilities.Prompt("Enter Patient Name");
                    patient.Age = utilities.GetNumber("ENter Age");
                    patient.BloodGroup = utilities.Prompt("Enter BloodGroup");
                    patient.Sex = utilities.Prompt("Enter Male or Female");
                    patient.Treatment = utilities.Prompt("Enter Disease Type");
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Providers", new SqlConnection("Data Source = 192.168.171.36; Initial Catalog = 3306; Integrated Security = True"));
                    try
                    {
                        cmd.Connection.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"Provider ID:{reader[0]}");
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    patient.ProviderID = utilities.GetNumber("ENter ID");
                    providers.AddPatient(patient);
                    Console.Clear();
                    goto RETRY;
                case 2:
                    ProviderMain providerMain = new ProviderMain();
                    providerMain.ProviderName = utilities.Prompt("Enter Provider Name");
                    providerMain.ProviderSpecial = utilities.Prompt("Enter Specialised Stream");
                    providers.AddProviders(providerMain);
                    Console.Clear();
                    goto RETRY;
                case 3:
                    int id = utilities.GetNumber("Enter Patient ID");
                    providers.DeletePatient(id);
                    Console.Clear();
                    goto RETRY;
                case 4:
                    int Newid = utilities.GetNumber("Enter Patient ID");
                    providers.UpdatePatient(Newid);
                    Console.Clear();
                    goto RETRY;
                case 5:
                    providers.GetAllPatients();
                    goto RETRY;
                case 6:
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    goto RETRY;
            }
        }
    }

    interface Provider
    {
        void AddPatient(Patient patient);
        void UpdatePatient(int id);
        void DeletePatient(int id);
        void AddProviders(ProviderMain providermain);

        void GetAllPatients();
    }


}
