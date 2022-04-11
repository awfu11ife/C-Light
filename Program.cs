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
            const string ShowPlayerInventory = "showinventory";
            const string ShowDealerInventory = "showdealerinventory";
            const string BuyCommand = "buy";
            const string ExitCommand = "exit";
            string playerInput = null;

            Player player = new Player(new List<Product>(0), 300);
            Dealer dealer = new Dealer(new List<Product> { new Product("Яблоко", 20), new Product("Зелье восстановления", 40), new Product("Зелье урона", 40), new Product("Меч", 100), new Product("Лук со стрелами", 200) });

            Console.WriteLine("Добро пожаловать в волшебную лавку\n");

            while (playerInput != ExitCommand)
            {
                Console.WriteLine($"Ваш баланс - {player.Balance}");
                Console.WriteLine($"Вам доступны следующие команды\n" +
                    $"{ShowPlayerInventory} - показать ваш инвентарь\n" +
                    $"{ShowDealerInventory} - показать ассортимент продавца\n" +
                    $"{BuyCommand} - купить товар\n" +
                    $"{ExitCommand} - уйти из лавки\n");
                playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case ShowPlayerInventory:
                        player.ShowInventory("В вашем инвентаре","Ваш инвентарь пуст");
                        break;

                    case ShowDealerInventory:
                        dealer.ShowInventory("В лавке продавца есть","У продавца не осталось товаров");
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

    class Participant
    {
        protected List<Product> Inventory;

        public void ShowInventory(string showInventoryMassage, string emptyInventoryMassage)
        {
            if (Inventory.Count > 0)
            {
                Console.WriteLine(showInventoryMassage);

                foreach (var product in Inventory)
                {
                    Console.WriteLine(product.Name + " по цене " + product.Price);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(emptyInventoryMassage + "\n");
            }
        }
    }

    class Player : Participant
    {
        private int _balance;

        public int Balance => _balance;

        public Player(List<Product> inventory, int balance)
        {
            Inventory = inventory;
            _balance = balance;
        }

        public void Buy(Dealer dealer)
        {
            Console.WriteLine("Введите название желаемого товара");
            string playerInput = Console.ReadLine();
            Product requiredProduct = null;

            requiredProduct = dealer.Sell(playerInput);

            if (requiredProduct != null)
            {
                if (requiredProduct.Price < _balance)
                {
                    _balance -= requiredProduct.Price;
                    Inventory.Add(requiredProduct);
                    Console.WriteLine("Сделка прошла успешно\n");
                }
                else
                {
                    Console.WriteLine("У вас недостаточно денег\n");
                }
            }
        }
    }

    class Dealer : Participant
    {
        public Dealer(List<Product> inventory)
        {
            Inventory = inventory;
        }

        public Product Sell(string playerInput)
        {
            if (Inventory.Count > 0)
            {
                Product requiredProduct = null;

                foreach (var product in Inventory)
                {
                    if (product.Name == playerInput)
                    {
                        requiredProduct = product;
                    }
                }

                if (requiredProduct != null)
                {
                    Inventory.Remove(requiredProduct);
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
