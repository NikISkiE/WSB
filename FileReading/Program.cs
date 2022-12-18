using System;
using System.ComponentModel.Design;

namespace FileReading
{
    internal class Program
    {
        static internal List<string> personlist = new List<string>();
        static void Main()
        {          
            string path = $"{Environment.CurrentDirectory}\\people.txt";
            Console.WriteLine(path);
            foreach (string person in File.ReadLines(path))
            {
                personlist.Add(person);
            }
            Selection();
            
        }

        static void Selection()
        {
            Console.WriteLine($"1.Wyświetl Element listy \n2.Wyświetl osoby o Wybranym imieniu");
            string sol = Console.ReadLine();

            switch (sol)
            {
                case "1":
                    SelectElement();
                    break;
                case "2":
                    CheckNames();
                    break;
                default:
                    Console.WriteLine("Podaj LICZBE z zakresu 1-2");
                    Console.ReadKey();
                    Selection();
                    break;
            }                     
        }
        static void SelectElement()
        {
            Console.WriteLine("Podaj numer szukanego elementu");
            if(!int.TryParse(Console.ReadLine(),out int value))
            {
                Console.WriteLine("Podaj Liczbe nie litere");
                Console.ReadKey();
                SelectElement();
            }
            Console.WriteLine(personlist[value-1]);
            Console.WriteLine($"--------------------\nWciśnij dowolny przycisk by wrócić na start..");
            Console.ReadKey();
            Selection();
        }
        static void CheckNames()
        {
            Console.WriteLine("Podaj szukanego imienia");
            string name = Console.ReadLine();
            name = name.ToLower();
            name = $"{name[0].ToString().ToUpper()}{name.Substring(1)}";
            foreach(string person in personlist)
            {
                if (person.Contains(name))
                    if (person.Substring(0, person.IndexOf(" ")) == name)
                        Console.WriteLine(person);
            }
            Console.WriteLine($"--------------------\nWciśnij dowolny przycisk by wrócić na start..");
            Console.ReadKey();
            Selection();
        }

    }
}