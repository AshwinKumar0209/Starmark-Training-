using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class FileIO
    {
        static void Main(string[] args)
        {
            //string filename = "../../FileIO.cs";
            //string filename = "D:/Starmark_Training/Ashwin_3306/.NET Programming/CompleteDotnetTraining/SampleFrameWork/FileIO.cs";
            //if (!File.Exists(filename))
            //{
            //    Console.WriteLine("File NOt FOund");
            //}
            //else
            //{
            //    var contents = File.ReadAllText(filename);
            //    Console.WriteLine(contents);
            //}   //-----------------------------------WORK-1------------------------------------------------------------------

            string deskTopFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "SampleFile.txt";
            writeFileExample(deskTopFile);
          }
        private static void writeFileExample(string desktopFile)
        {
            //File.WriteAllText(desktopFile, "Hi All");
            File.AppendAllText(desktopFile,"Bye All" );
        }
    }
}
