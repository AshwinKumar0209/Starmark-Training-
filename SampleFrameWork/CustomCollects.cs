using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWork
{
    class CustomCollects 
    {
        class CustomArray: IEnumerable
        {
            List<string> names = new List<string>();

            public string[] GetallNames()
            {
                return names.ToArray();
            }
            public void AddNames(string name)
            {
                names.Add(name);
            }
            public void DeleteName(int index)
            {
                if (index < names.Count)
                    names.RemoveAt(index);
                else
                    throw new Exception("ID is not Found");
            }

            public string this[int index]
            {
                get
                {
                    return names[index];
                }
                set
                {
                    if (index < names.Count)
                    {
                        names[index] = value;
                    }
                }
            }

            public IEnumerator GetEnumerator()
            {
                foreach (var item in names)
                {

                    yield return item;
                }
            }
            public int NamesCount => names.Count;
        }
            
        static void Main(string[] args)
        {
            CustomArray Array = new CustomArray();

            Array.AddNames("Ashwin");
            Array.AddNames("Bhavan");
            Array.AddNames("Deepa");
            Array.AddNames("Chitra");
            Array.AddNames("Yuva");

            foreach (string item in Array)
            {
                Console.WriteLine(item);
            }
            for (int i = 0; i < Array.NamesCount; i++)
            {
                string old = Array[i];
                Array[i] = "Welcome to " + old;

                Console.WriteLine(Array[i]);
            }

         
            {

            }
        }

    }
}
