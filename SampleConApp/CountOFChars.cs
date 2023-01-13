using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class CountOFChars
    {


        //static public  void CountChar(string length)
        //{
        //    int couuntChar = 0;
        //    int couuntNum = 0;
        //    int couuntSpl = 0;
        //    string Chars = length;

        //    for (int i = 0;i< Chars.Length; i++)
        //    {
        //        if (Chars[i] ==  )
        //        {
        //            couuntChar = +1;
        //        }

        //    }

        //}

        //static void Main(string[] args)
        //{
        //    string leng = utilities.Prompt("ENter the string");

        //    CountChar(leng);
        //}

            public static void ConvertToggle(string name)
        {
            string name_ = name;
            int len = name_.Length;
             
            string[] _name = new string[len];

            for(int i = 0; i < name_.Length; i++)
            {

                _name[i] = char.ToString(name_[i]);

                if(_name[i]== _name[i].ToUpper())
                {
                    Console.Write(_name[i].ToLower());
                }
                if(_name[i]==_name[i].ToLower())
                {
                    Console.Write(_name[i].ToUpper());
                }
            }

        }

        static void Main(string[] args)
        {
            string name = utilities.Prompt("Enter String");
            ConvertToggle(name);
        }

     

    }
}
