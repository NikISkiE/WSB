using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace LiczbyPierwsze
{
    internal class LiczbyPierwsze
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int a;
            Console.WriteLine("Wprowadź Liczbę do sprawdzenia: ");
            if(!int.TryParse(Console.ReadLine(),out a))
            {
                Console.WriteLine("Wprowadź liczbę nie literę");
                Console.ReadKey();
                Main(args);
            }                
            Console.Clear();
            if (ISFirstNumber(a))
            {
                Console.WriteLine($"Liczba {a} jest liczbą pierwszą");
            }
            else
            {
                Console.WriteLine($"Liczba {a} nie jest liczbą pierwszą");
            }
            Console.WriteLine("\nKliknij 'enter' a by wybrać nową liczbe.... ");
            Console.ReadKey();
            Main(args);

        }

        static bool ISFirstNumber(int a, int b=3)
        {
            if (a % 2 == 0)
                return (a == 2);
            if(b <= Math.Sqrt(a))
            {
                if (a % b == 0)
                    return false;
                ISFirstNumber(a,b+2);
            }
            return (a>1);
        }
    }
}