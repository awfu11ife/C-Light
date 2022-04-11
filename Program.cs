using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork43
{
    class Program
    {
        static void Main(string[] args)
        {
            StartBidding();
        }

        static void StartBidding()
        {
            Player player = new Player(new List<Product>(0));
            Dealer dealer = new Dealer(new List<Product> { new Product("Яблоко"), new Product("Зелье восстановления"), new Product("Зелье урона"), new Product("Меч"), new Product("Лук со стрелами") });

            const string ShowPlayerInventory = "showinventory";
            const string ShowDealerInventory = "showdealerinventory";
            const string BuyCommand = "buy";
            const string ExitCommand = "exit";
            string playerInput = null;

            Console.WriteLine("Добро пожаловать в волшебную лавку\n");

            while (playerInput != ExitCommand)
            {
                Console.WriteLine($"Вам доступны следующие команды\n" +
                    $"{ShowPlayerInventory} - показать ваш инвентарь\n" +
                    $"{ShowDealerInventory} - показать ассортимент продавца\n" +
                    $"{BuyCommand} - купить товар\n" +
                    $"{ExitCommand} - уйти из лавки\n");
                playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case ShowPlayerInventory:
                        player.ShowInventory();
                        break;

                    case ShowDealerInventory:
                        dealer.ShowInventory();
                        break;

                    case BuyCommand:
                        player.Buy(dealer);
                        break;

                    case ExitCommand:
                        break;

                    default:
                        Console.WriteLine("Такой команды нет\n");
                        break;
                }
            }
        }
    }

    class Player
    {
        private List<Product> _inventory;

        public Player(List<Product> inventory)
        {
            _inventory = inventory;
        }

        public void Buy(Dealer dealer)
        {
            Console.WriteLine("Введите название желаемого товара");
            string playerInput = Console.ReadLine();
            Product requiredProduct = null;

            requiredProduct = dealer.Sell(playerInput);

            if (requiredProduct != null)
            {
                _inventory.Add(requiredProduct);
                Console.WriteLine("Сделка прошла успешно\n");
            }
        }

        public void ShowInventory()
        {
            if (_inventory.Count > 0)
            {
                foreach (var product in _inventory)
                {
                    Console.WriteLine(product.Name);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ваш ивентарь пуст\n");
            }
        }
    }

    class Dealer
    {
        private List<Product> _inventory;

        public Dealer(List<Product> inventory)
        {
            _inventory = inventory;
        }

        public Product Sell(string playerInput)
        {
            if (_inventory.Count > 0)
            {
                Product requiredProduct = null;

                foreach (var product in _inventory)
                {
                    if (product.Name == playerInput)
                    {
                        requiredProduct = product;
                    }
                }

                if (requiredProduct != null)
                {
                    _inventory.Remove(requiredProduct);
                    Console.WriteLine();
                    return requiredProduct;
                }
                else
                {
                    Console.WriteLine("Такого товара нет\n");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("У продавца не осталось товаров\n");
                return null;
            }
        }

        public void ShowInventory()
        {
            foreach (var product in _inventory)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine();
        }
    }

    class Product
    {
        private string _name;

        public string Name => _name;

        public Product(string name)
        {
            _name = name;
        }
    }
}
