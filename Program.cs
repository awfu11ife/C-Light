using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork44
{
    class Program
    {
        static void Main(string[] args)
        {
            StartProgram();
        }

        static void StartProgram()
        {
            const string StopCommand = "stop";
            const string CreatePlanCommand = "createplan";
            string userInput = null;

            Console.WriteLine("В этой программе вы можете создавать план поезда");
            Console.WriteLine("В данный момент рейс отсутствует\n");

            while (userInput != StopCommand)
            {
                Console.WriteLine($"Вам доступны следующие команды\n" +
                    $"{CreatePlanCommand} - создать план поезда\n" +
                    $"{StopCommand} - завершить программу\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CreatePlanCommand:
                        CreatePlan();
                        break;

                    case StopCommand:
                        break;

                    default:
                        Console.WriteLine("Такой команды нет\n");
                        break;
                }
            }
        }

        static void CreatePlan()
        {
            Tickets tickets = new Tickets();
            Train train = new Train(new List<Wagon>(0));
            Direction direction = CreateRoute();

            tickets.Show();

            int currentWagon = 1;
            int numberOfPassangers = tickets.Amount;
            int numberOfPassangersInCurrentWagon;
            bool isCorrect = true;

            while (numberOfPassangers > 0)
            {
                Console.WriteLine($"Введите количество мест, которое хотите создать для вагона номер {currentWagon}");
                if (isCorrect == int.TryParse(Console.ReadLine(), out int amount))
                {
                    numberOfPassangersInCurrentWagon = amount;
                    numberOfPassangers -= numberOfPassangersInCurrentWagon;
                    train.AttachWagon(new Wagon(numberOfPassangersInCurrentWagon));
                    currentWagon++;
                    Console.WriteLine($"Осталось посадить {numberOfPassangers} пассажиров");
                }
                else
                {
                    Console.WriteLine("Это не число, попробуйте ещё раз");
                    continue;
                }
            }

            currentWagon = 1;
            Console.Clear();
            direction.Show();
            tickets.Show();
            train.Send();
            Console.ReadLine();
        }

        static Direction CreateRoute()
        {
            Console.WriteLine("Откуда следует поезд");
            string fromDirection = Console.ReadLine();
            Console.WriteLine("Куда следует поезд");
            string toDirection = Console.ReadLine();

            Direction direction = new Direction(fromDirection, toDirection);
            return direction;
        }
    }

    class Direction
    {
        private string _from;
        private string _to;

        public Direction(string from, string to)
        {
            _from = from;
            _to = to;
        }

        public void Show()
        {
            Console.WriteLine($"Поезд следует маршрутом {_from} - {_to}");
        }
    }

    class Tickets
    {
        private int _amount;
        private int _minAmount = 100;
        private int _maxAmount = 300;
        private Random _random = new Random();

        public int Amount => _amount;

        public Tickets()
        {
            _amount = _random.Next(_minAmount, _maxAmount);
        }

        public void Show()
        {
            Console.WriteLine($"На данное направление купили {_amount} билетов");
        }
    }

    class Train
    {
        private List<Wagon> _wagons;

        public Train(List<Wagon> wagons)
        {
            _wagons = wagons;
        }

        public void AttachWagon(Wagon wagon)
        {
            _wagons.Add(wagon);
            Console.WriteLine("Вагон успешно прицеплен");
        }

        public void Send()
        {
            Console.WriteLine($"Поезд из {_wagons.Count} вагонов отправлен");
        }
    }

    class Wagon
    {
        private int _numberOfSits;

        public int NumberOfSits => _numberOfSits;

        public Wagon(int numberOfSits)
        {
            _numberOfSits = numberOfSits;
        }
    }
}
