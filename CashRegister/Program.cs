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
    class Item
    {

        public string name { get; set; }

        public string priceperitem { get; set; }

        public string priceperkg { get; set; }

    }
    internal class Program
    {
        
        static void Refresh()
        {
            Console.Clear();
        }
        static readonly List<Item> itemslist = new List<Item>
            {
            new Item { name = "Potato", priceperitem = "-", priceperkg = "1,30" },
            new Item { name = "Coca Cola 1.5l",priceperitem="6,00",priceperkg="-"},
            new Item { name = "Lays 350g",priceperitem="4,45",priceperkg="-"},
            new Item { name = "Chicken Breast",priceperitem="-",priceperkg="3,79"},
            new Item { name = "Milk 1l",priceperitem="2,49",priceperkg="-"}
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
            HowMuch(a - 1);


        }
        static decimal PricePer(int item)
        {
            decimal a;
            if (itemslist[item].priceperitem == "-")
            {
                a = decimal.Parse(itemslist[item].priceperkg);
                return a;
            }
            a = decimal.Parse(itemslist[item].priceperitem);
            return a;
        }
            
        static void HowMuch(int item)
        {
            Refresh();            
            Console.WriteLine($"Podaj ilość {itemslist[item].name}");

            if (!decimal.TryParse(Console.ReadLine(), out decimal a))
            {
                Refresh();
                Console.WriteLine("Podaj Liczbe nie litere!!! \nWciśnij przycisk by wrócić do wyboru");
                Console.ReadKey();
                HowMuch(item);
            }
            if (itemslist[item].priceperkg == "-")
            {
                if((a % 1)!=0)
                {
                    Console.WriteLine("Nie można wziąć nie pełniej sztuki\nWciśnij przycisk by wrócić do wyboru");
                    Console.ReadKey();
                    HowMuch(item);
                }
            }
            decimal price = PricePer(item);
            a = Decimal.Round(a, 2);
            decimal sum = price * a;
            sum = Decimal.Round(sum, 2);

            invoicelist.Add(new Invoice { name = itemslist[item].name, amount = a, priceper = price, sum = sum });
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
            Console.WriteLine($"Wciśnij przycisk by wrócić do ekranu startowego");
            Console.ReadKey();
            Main();

        }

        static void Main()
        {
            
            Console.WriteLine("Welcome\nWciśnij przycisk by kontynuować");
            Console.ReadKey();
            ItemSelection();
        }
    }
}