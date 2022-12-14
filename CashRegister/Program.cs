using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CashRegister
{
    class Invoice
    {

        public string name { get; set; }

        public decimal amount { get; set; }

        public decimal priceper { get; set; }

        public decimal sum { get; set; }


    }
    struct Item
    {

        public string name { get; set; }

        public decimal priceperitem { get; set; }

        public decimal priceperkg { get; set; }

    }
    internal class Program
    {
        
        static void Refresh()
        {
            Console.Clear();
        }
        static readonly List<Item> itemslist = new List<Item>
            {
            new Item { name = "Potato", priceperitem =1.50m, priceperkg = 1.30m },
            new Item { name = "Coca Cola 1.5l",priceperitem=6.00m,priceperkg=2.00m},
            new Item { name = "Lays 350g",priceperitem=4.45m,priceperkg=12.99m},
            new Item { name = "Chicken Breast",priceperitem=14.49m,priceperkg=3.79m},
            new Item { name = "Milk 1l",priceperitem=2.49m,priceperkg=2.49m}
            };
        static internal List<Invoice> invoicelist = new List<Invoice>();

        static void ItemSelection()
        {
            Refresh();
            int i = 0;
            Console.WriteLine("Select Item:");
            foreach (var item in itemslist)
            {
                ++i;
                Console.WriteLine($"{i}. {item.name} ");
                
            }

            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Refresh();
                Console.WriteLine("Podaj Liczbe nie litere!!! \nWciśnij przycisk by wrócić do wyboru");
                Console.ReadKey();
                ItemSelection();
            }

            if (a > i || a == 0)
            {
                Refresh();
                Console.WriteLine($"Liczba musi być z zakresu 1-{i} \nWciśnij przycisk by wrócić do wyboru");
                Console.ReadKey();
                ItemSelection();
            }
            PricePerWhat(itemslist[a-1]);


        }
        static void PricePerWhat(Item item)
        {
            Refresh();
            Console.WriteLine($"1.Cena za kilogram\n2.Cena za sztuke");
            if (!int.TryParse(Console.ReadLine(), out int selection))
            {
                Console.WriteLine("Podaj Liczbe nie litere!!! \nWciśnij przycisk by wrócić do wyboru");
                Console.ReadKey();
                PricePerWhat(item);
            }

            switch (selection)
            {
                case 1:
                    HowMuch(item, item.priceperkg);
                    break;
                case 2:
                    HowMuch(item,item.priceperitem);
                    break;
                default:
                    Console.WriteLine("Podaj Liczbe z zakresu 1-2\nWciśnij przycisk by wrócić do wyboru");
                    Console.ReadKey();
                    PricePerWhat(item);
                    break;              
            
            }
        }
            
        static void HowMuch(Item item, decimal price)
        {
            Refresh();            
            Console.WriteLine($"Podaj ilość {item.name}");

            if (!decimal.TryParse(Console.ReadLine(), out decimal a))
            {
                Refresh();
                Console.WriteLine("Podaj Liczbe nie litere!!! \nWciśnij przycisk by wrócić do wyboru");
                Console.ReadKey();
                HowMuch(item, price);
            }
            if (item.priceperkg == price)
            {
                if((a % 1)!=0)
                {
                    Console.WriteLine("Nie można wziąć nie pełniej sztuki\nWciśnij przycisk by wrócić do wyboru");
                    Console.ReadKey();
                    HowMuch(item, price);
                }
            }
            a = Decimal.Round(a, 2);
            decimal sum = price * a;
            sum = Decimal.Round(sum, 2);

            invoicelist.Add(new Invoice { name = item.name, amount = a, priceper = price, sum = sum });
            IFMore();

        }

        static void IFMore()
        {
            Refresh();
            Console.WriteLine($"Dodać Kolejny przedmiot?\n1.yes\n2.no");
            switch (Console.ReadLine())
            {
                case "1":
                    ItemSelection();
                    break;
                case "2":
                    ShowInvoice();
                    break;
                default:
                    Console.WriteLine("Podaj liczbe z zakresu 1-2!!\nWciśnij przycisk by wrócić do wyboru...");
                    Console.ReadKey();
                    IFMore();
                    break;

            }
        }
        static void ShowInvoice()
        {
            Refresh();
            int i = 0;
            decimal finalsum = 0;
            foreach(var item in invoicelist)
            {
                ++i;
                Console.WriteLine($"{i}. {item.name} {item.amount} X {item.priceper}.........{item.sum}");
                finalsum = finalsum + item.sum;
            }
            finalsum = Decimal.Round(finalsum, 2);
            Console.WriteLine($"Suma  PLN............{finalsum}");
            Console.WriteLine($"Wciśnij (ENTER) by rozpocząć nowe zamówienie\nWciśnij (ESC) by wyjść z programu");
            var option = Console.ReadKey();
            switch (option.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Enter:
                    ItemSelection();
                    break;
                default:
                    ShowInvoice();
                    break;
            }
            ItemSelection();

        }

        static void Main()
        {
            
            Console.WriteLine("Welcome\nWciśnij przycisk by kontynuować");
            Console.ReadKey();
            ItemSelection();
        }
    }
}