using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class ArrayTranspose
    {
        //    static public void Transpose(int[,] mat)
        //    {
        //        int[,] Tmat= mat;
        //        Console.WriteLine("Regular method");
        //        for (int i = 0; i < Tmat.GetLength(1); i++) {

        //            for(int j = 0; j < Tmat.GetLength(0); j++)
        //            {
        //                Console.Write(Tmat[j,i]+" " );
        //            }
        //            Console.WriteLine();

        //        }



        //    }

            static public void AddColumn(int[,] mat)
        {
            int[,] Tmat = mat;
            
            for (int i=0;i<Tmat.GetLength(0);i++)
            {
                int sum = 0;
                for (int j=0;j<Tmat.GetLength(1);j++)
                {
                    Console.Write(Tmat[i,j]+" ");
                 
                    sum += Tmat[i, j];

                }
                Console.Write(sum);
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            int[,] mat = { {1, 2, 3},
                             { 4, 5, 6 } };
            AddColumn(mat);

        }

        }

    }
