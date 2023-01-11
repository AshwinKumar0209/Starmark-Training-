using System;
using System.Collections;
using System.Threading;
using SampleConApp;
namespace SampleFrameWork.Hackathon_2

{   
    class DiseaseDetails
    {
        
        public string DiseaseName { get; set; }
        public string Severity { get; set; }

        public string Symptom { get; set; }


    }

    class Sympthoms : DiseaseDetails
    {
        private ArrayList Disease = new ArrayList();
        public bool AddDisease(DiseaseDetails dis)
        {
            Disease.Add(dis);
            Console.WriteLine("Added Successfully...");
            return true;
        }
        public Array DisplayDis()
        {

            return Disease.ToArray();  
           
        }
        public bool CheckSymptoms(string Sym)
        {
            for(int i = 0; i < Disease.Count; i++)
            {
                if(Disease[i] is DiseaseDetails)
                {
                    var data = Disease[i] as DiseaseDetails;
                    if (data.Symptom == Sym)
                    {
                        Console.WriteLine("The patient may have {0}",data.DiseaseName);
                        return true;
                    }
                }
            }

            return false;
        }

    }

    class PatientDetails: Sympthoms
    {
        public string  PatName { get; set; }
        public string PatSym { get; set; }

        public ArrayList PatDet { get; set; }

     public   void SetDet(PatientDetails pat)
        {
            PatDet.Add(pat);
        }


     
    }

   


    class Patient
    {
      static  public void Run()
        {
           
            Console.WriteLine("Press 1 To Add Disease");
            Console.WriteLine("press 2 to Take Advise");
            P:
            int choice = utilities.GetNumber("ENter choice");
            switch (choice)
            {
                case 1:
                    HelperAdd();
                    break;
                default:
                    Console.WriteLine("Invalid Choice Enter Again");
                    goto P;
            }

        }

        static public void HelperAdd()
        {

            Sympthoms Sym = new Sympthoms();
            void SeverityCheck(string SeverityBool)
            {
                if(SeverityBool.ToUpper() == "HIGH" || SeverityBool.ToUpper()=="LOW" || SeverityBool.ToUpper() == "MEDIUM")
                {
                    Console.WriteLine("Valid Entry");
                }
                else
                {
                    throw new Exception("Invalid Choice");
                }
            }
        P:
            string DisName = utilities.Prompt("ENter Disease Name");
            
            string Severity = utilities.Prompt("Enter Severity level Options are \n HIGH\n MEDIUM \n LOW");
            try
            {
                SeverityCheck(Severity);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto P;
            }
            string EnteredSymptoms = utilities.Prompt("Enter Symptoms");


            DiseaseDetails dis = new DiseaseDetails();
            dis.DiseaseName = DisName;
            dis.Severity = Severity;
            dis.Symptom = EnteredSymptoms;
             Sym.AddDisease(dis);



            string ChoiceAdd = utilities.Prompt("Add Another disease");
            
              if (ChoiceAdd.ToUpper() == "YES")
                {
                    goto P;
                }
 
           



            
            string PatName = utilities.Prompt("Patient Name");
            string PatSym = utilities.Prompt("Guide us Through ur Symtoms");
            //PatientDetails pat = new PatientDetails();
            //pat.PatName = PatName;
            //pat.PatSym = PatSym;


            Console.WriteLine("Checking With Symptoms__________________________");
            Thread.Sleep(2000);

            Sym.CheckSymptoms(PatSym);
         
            //Console.WriteLine("The disease Entered is  ");
            //var data = Sym.DisplayDis();
            //foreach (var DiseaseDetails in data)
            //{
            //    Console.WriteLine("Diseases Daignosis we have with us {0} with sympthom {1} ", ((DiseaseDetails)DiseaseDetails).DiseaseName, ((DiseaseDetails)DiseaseDetails).Symptom);
            //}

        }

    


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Starmark HealthCare System");
            Console.WriteLine("Primarily we Advise you to add disease");

            Run();


        }

            
    }
}
