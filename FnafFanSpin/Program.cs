using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace FnafFanSpin
{
    internal class Program
    {
        internal char[,] table;

        internal void Spin(int degree)
        {
            for (int i = 0; i < degree; i++)
            {
                char c1 = table[0, 0];
                char c2 = table[3, 0];
                char c3 = table[3, 3];
                char c4 = table[0, 3];
                for(int j = 0; j < 6; j++)
                {
                    
                    if(j <= 2)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if(k <= 2)
                            {
                                table[j, k] = c2;
                            }
                            else
                            {
                                table[j, k] = c1;
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < 6; k++) 
                        {
                            if (k <= 2)
                            {
                                table[j, k] = c3;
                            }
                            else
                            {
                                table[j, k] = c4;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.Write("\n");
            }

            Choice();
        }

        internal void Choice()
        {
            Console.WriteLine(
                @"1.obróć w prawo o 90o
2.obróć w prawo o 180o  
3.obróć w prawo o 270o  
4.Zresetuj układ"
            );
            string userselection = Console.ReadLine();
            string[] possibldegree = {"1", "2", "3"};

            if (possibldegree.Contains(userselection))
            {
                Console.Clear();
                Spin(int.Parse(userselection));
            }
            else if (userselection == "4")
            {
                Main();
            }
            else
            {
                Console.WriteLine("Podano dane z poza zasiegu wybierz liczbe 1-4");
                Choice();
            }
        }

        static void Main()
        {
            Program p = new Program();
            Console.Clear();
            p.table = new char[6, 6] {
                { '%','%','%','#','#','#'},
                { '%','%','%','#','#','#'},
                { '%','%','%','#','#','#'},
                { '*','*','*','+','+','+'},
                { '*','*','*','+','+','+'},
                { '*','*','*','+','+','+'},
            };
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(p.table[i, j]);
                }
                Console.Write("\n");
            }
            p.Choice();            
        }

    }
}