using System.Globalization;
using System.Text.RegularExpressions;

namespace PhoneBook
{
    internal class Program
    {
        static internal Dictionary<string, string> PhoneBook = new Dictionary<string, string>()
        {
            {"521542542","Alan Kat"},
            {"254235432","Izabela Andr"},
            {"412531251","Alan Kat"},
            {"512543512","Jacob Sober"},
            {"415632630","Mateusz Yzikiel"},
            {"421321465","Kamil Torent"},
            {"412234567","John Smith"},
            {"865467477","Jhon Smith"},
            {"745647467","Juan Patriot"},
            {"788564846","John Doe"},
            {"746584468","Joe Jonson"}
        };

        static void Refresh()
        {
            Console.Clear();
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("\\\\\\\\\\\\Witam w książce telefonicznej//////");
            int x = 1;
            do {
                Console.WriteLine("- [w]  Wyświetlanie całej książki telefonicznej\r\n- [s] Szukanie po nazwisku i imieniu\r\n- [a] Szukanie po numerze telefonu\r\n- [d] Dodawanie nowego wpisu do książki\r\n- [esc] wyjście z programu");
                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        ++x;
                        break;
                    case ConsoleKey.W:
                        ShowPBook();
                        break;
                    case ConsoleKey.S:
                        SearchNamePBook();
                        break;
                    case ConsoleKey.A:
                        SearchNumberPBook();
                        break;
                    case ConsoleKey.D:
                        AddNewEntry();
                        break;
                }
                Refresh();
            } while (x == 1);
        }

        static void ShowPBook()
        {
            Refresh();
            foreach (KeyValuePair<string,string> residant in PhoneBook)
            {
                Console.WriteLine("Numer Telefonu = {0} | Imię i Nazwisko = {1}", residant.Key, residant.Value);
            }
            Console.ReadKey();
        }

        static void SearchNamePBook()
        {
            Refresh();            
            Console.WriteLine("Podaj Nazwisko i Imię szukanej osoby");           
            string person = Console.ReadLine();
            person = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(person.ToLower());
            string[] elements = person.Split(' ');;

            if (elements.Count() == 2)
            {
                if (PhoneBook.ContainsValue(elements[1] + " " + elements[0]) || PhoneBook.ContainsValue(person))
                {
                    List<string> numbers = new List<string>();
                    foreach (var residant in PhoneBook)
                    {
                        if (residant.Value.Contains(elements[1] + " " + elements[0]) || residant.Value.Contains(person))
                        {
                            numbers.Add(residant.Key);
                        }
                    }
                    foreach (var number in numbers)
                    {
                        Console.WriteLine("Numer Telefonu = {0} | Imię i Nazwisko = {1}", number, PhoneBook[number]);
                    }

                }else
                {
                    Console.WriteLine("Podana Osoba nie znajduję sie w naszej bazie danych lub podano złą wartość");
                };
            }else if (elements.Count() == 1)
            {
                    List<string> numbers = new List<string>();
                    foreach (var residant in PhoneBook)
                    {
                        string[] nameandsurname = residant.Value.Split(' ');
                        if (nameandsurname[0] == person || nameandsurname[1] == person)
                        {
                            numbers.Add(residant.Key);
                        }
                    }
                    if (numbers.Count() > 0)
                    {
                        foreach (var number in numbers)
                        {
                            Console.WriteLine("Numer Telefonu = {0} | Imię i Nazwisko = {1}", number, PhoneBook[number]);
                        }
                    }else
                    {
                        Console.WriteLine("Podana Osoba nie znajduję sie w naszej bazie danych lub podano złą wartość");
                    }
            }else
            {
                Console.WriteLine("Podana Osoba nie znajduję sie w naszej bazie danych lub podano złą wartość");
            };
            Console.ReadKey();
        }

        static void SearchNumberPBook()
        {
            Refresh();
            Console.WriteLine("Podaj Numer szukanej osoby");
            string number = Console.ReadLine();
            if (PhoneBook.ContainsKey(number))
            {
                Console.WriteLine("Numer Telefonu = {0} | Imię i Nazwisko = {1}", number, PhoneBook[number]);
            }
            else
            {
                Console.WriteLine("Podana Numer nie znajduję sie w naszej bazie danych lub podano złą wartość");
            }
            Console.ReadKey();
        }

        static void AddNewEntry()
        {
            Refresh();
            Console.WriteLine("Podaj Imie i Nazwisko dodawanej osoby");
            string person = Console.ReadLine();
            person = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(person.ToLower());
            string[] nameandsurname = person.Split(" ");
            Console.WriteLine("Podaj Numer dodawanej osoby");
            string number = Console.ReadLine();
            
            if(nameandsurname.Count() == 2 && number.Length == 9 && int.TryParse(number,out int res))
            {
                try
                {
                    PhoneBook.Add(number, person);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Osoba z numerem {0} już istnieje",number);
                }
            }
            else
            {
                Console.WriteLine("Jedna z podanych wartości jest błędna numer musi posiadać dokładnie 9 cyfr, należy podać tylko pierwsze imię i nazwisko przedzielone spacją");
            }

            Console.ReadKey();
        }
    }
}