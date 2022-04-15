﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork46
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> allProducts = new List<Product> { new Product("Сыр", 150), new Product("Молоко", 50), new Product("Макароны", 70), new Product("Масло", 200), new Product("Хлеб", 50) };
            Superarket cashRegistes = new Superarket(new Queue<Buyer>(), 7);

            cashRegistes.StartServing(allProducts);
        }
    }

    class Superarket
    {
        private Queue<Buyer> _buyers = new Queue<Buyer>();
        private int _queueLenght;
        private int _revenue = 0;

        public Superarket(Queue<Buyer> buyers, int queueLenght)
        {
            _buyers = buyers;
            _queueLenght = queueLenght;
        }

        public void StartServing(List<Product> allProducts)
        {
            CreateQueue(_queueLenght);

            while (_buyers.Count > 0)
            {
                SereveBuyer(allProducts);
                Console.WriteLine($"Чтобы обслужить следующего клиента нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Общая выручка - {_revenue}");
        }

        private void SereveBuyer(List<Product> allProducts)
        {
            Buyer currentBuyer = _buyers.Dequeue();
            currentBuyer.CreateBascket(allProducts);
            Console.WriteLine($"У покупателя {currentBuyer.Money} рублей\n");
            currentBuyer.ShowBasket();
            currentBuyer.CountPriceAmout();

            while (currentBuyer.Money < currentBuyer.PriceAmount)
            {
                Console.WriteLine($"Поккупателю нехванает {currentBuyer.PriceAmount - currentBuyer.Money} рублей");
                currentBuyer.RemoveRandomProduct();
            }

            CountRenue(currentBuyer);
            Console.WriteLine($"С этого клиента вы получили - {currentBuyer.PriceAmount} рублей");
        }

        private void CountRenue(Buyer currentBuyer)
        {
            _revenue += currentBuyer.PriceAmount;
        }

        private void CreateQueue(int count)
        {
            Random random = new Random();
            int maxMoneyAmount = 800;
            int minMoneyAmount = 300;

            for (int i = 0; i < count; i++)
            {
                _buyers.Enqueue(new Buyer(random.Next(minMoneyAmount, maxMoneyAmount)));
            }
        }
    }

    class Buyer
    {
        private List<Product> _basket = new List<Product>();

        public int Money { get; private set; }
        public int PriceAmount { get; private set; }

        public Buyer(int money)
        {
            Money = money;
        }

        public void CreateBascket(List<Product> allProducts)
        {
            Random random = new Random();
            int maxProductAmount = 10;
            int minProductAmount = 5;
            List<Product> basket = new List<Product>();

            for (int i = minProductAmount; i <= maxProductAmount; i++)
            {
                basket.Add(allProducts[random.Next(0, allProducts.Count)]);
            }

            _basket = basket;
        }

        public void ShowBasket()
        {
            Console.WriteLine("В корзине находятся:");

            foreach (var product in _basket)
            {
                Console.WriteLine($"Товар {product.Name} по цене {product.Price}");
            }
        }

        public void CountPriceAmout()
        {
            int currentPriceAmount = 0;

            foreach (var product in _basket)
            {
                currentPriceAmount += product.Price;
            }

            PriceAmount = currentPriceAmount;
            Console.WriteLine($"\nТекущая цена корзины {PriceAmount}\n");
        }

        public void RemoveRandomProduct()
        {
            Random random = new Random();
            int randomProductIndex = random.Next(0, _basket.Count - 1);

            Console.WriteLine($"Из корзины убран товар {_basket[randomProductIndex].Name}");
            PriceAmount -= _basket[randomProductIndex].Price;
            Console.WriteLine($"Текущая цена корзины {PriceAmount}\n");
            _basket.RemoveAt(randomProductIndex);
        }
    }

    class Product
    {
        private string _name;
        private int _price;

        public string Name => _name;
        public int Price => _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }
}