using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork55
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse(30);
            warehouse.ShowAllStews();
            warehouse.ShowExpiredStews();
        }
    }

    class Warehouse
    {
        private int _currentYear = 2022;
        private List<Stew> _stews = new List<Stew>();

        public Warehouse(int number)
        {
            Fill(number);
        }

        public void ShowExpiredStews()
        {
            var expiredStews = _stews.Where(stew => _currentYear - stew.ProductYear > stew.ExpirationDate);
            Console.WriteLine("\nИз них просрочены:\n");

            foreach (var stew in expiredStews)
            {
                stew.ShowInfo();
            }
        }

        public void ShowAllStews()
        {
            Console.WriteLine("В хранилище сейчас находятся:\n");

            foreach (var stew in _stews)
            {
                stew.ShowInfo();
            }
        }

        private void Fill(int number)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                _stews.Add(new Stew(random));
            }
        }
    }

    class Stew
    {
        public string Name { get; private set; }
        public int ProductYear { get; private set; }
        public int ExpirationDate { get; private set; }

        public Stew(Random random)
        {
            List<string> names = new List<string> { "Свинина", "Говядина", "Индейка", "Куриуа" };
            int minProductYear = 2017;
            int maxProductYear = 2020;
            int minExpirationDate = 3;
            int maxExpirationDate = 6;

            Name = names[random.Next(0, names.Count)];
            ProductYear = random.Next(minProductYear, maxProductYear);
            ExpirationDate = random.Next(minExpirationDate, maxExpirationDate);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Тушенка со квусом {Name}, произведена в {ProductYear} году, срок годности {ExpirationDate} года");
        }
    }
}
