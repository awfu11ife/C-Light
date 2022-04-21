using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork51
{
    class Program
    {
        static void Main(string[] args)
        {
            StartWork();
        }

        static void StartWork()
        {
            const string ShowAllCriminals = "showall";
            const string Search = "search";
            const string ExitCommand = "exit";
            string userInput = null;
            DataBase dataBase = new DataBase(20);

            Console.WriteLine("Добро пожаловать в базу данных преступников\n");

            while (userInput != ExitCommand)
            {
                Console.WriteLine($"Вам доступны следующие команды\n" +
                    $"{ShowAllCriminals} - показать всю базу данных\n" +
                    $"{Search} - найти по параметрам\n" +
                    $"{ExitCommand} - выйти\n");
                Console.WriteLine();
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllCriminals:
                        dataBase.ShowAllCriminals();
                        break;

                    case Search:
                        dataBase.ShowCriminalsByParameters();
                        break;

                    case ExitCommand:
                        break;

                    default:
                        Console.WriteLine("Такой команды нет, попробуйте езё раз");
                        break;
                }
            }
        }
    }

    class DataBase
    {
        private LinkedList<Criminal> _criminals = new LinkedList<Criminal>();

        public DataBase(int count)
        {
            Create(count);
        }

        public void ShowAllCriminals()
        {
            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void ShowCriminalsByParameters()
        {
            int targetMaxHeight;
            int targetMinHeight;
            int targetMaxWeight;
            int targetMinWeight;
            string targetNationality;
            bool isCorrectInput;

            Console.WriteLine("Введите максимальный и минимальный рост");
            isCorrectInput = int.TryParse(Console.ReadLine(), out targetMaxHeight);

            if (isCorrectInput)
            {
                isCorrectInput = int.TryParse(Console.ReadLine(), out targetMinHeight);

                if (isCorrectInput)
                {
                    Console.WriteLine("Введите максимальный и минимальный вес");
                    isCorrectInput = int.TryParse(Console.ReadLine(), out targetMaxWeight);

                    if (isCorrectInput)
                    {
                        isCorrectInput = int.TryParse(Console.ReadLine(), out targetMinWeight);

                        if (isCorrectInput)
                        {
                            Console.WriteLine("Введите национальность");
                            targetNationality = Console.ReadLine();

                            var filteredCriminals = _criminals.Where(criminal => criminal.Hieght >= targetMinHeight && criminal.Hieght <= targetMaxHeight && criminal.Weight >= targetMinWeight && criminal.Weight <= targetMaxWeight && criminal.Nationality == targetNationality && criminal.IsConvicted == false);

                            foreach (var criminal in filteredCriminals)
                            {
                                criminal.ShowInfo();
                            }

                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Упс, что-то пошло не так....");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Упс, что-то пошло не так....");
                    }
                }
                else
                {
                    Console.WriteLine("Упс, что-то пошло не так....");
                }
            }
            else
            {
                Console.WriteLine("Упс, что-то пошло не так....");
            }
        }

        private void Create(int count)
        {
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                _criminals.AddLast(new Criminal(random));
            }
        }
    }

    class Criminal
    {
        public string Initials { get; private set; }
        public string Nationality { get; private set; }
        public bool IsConvicted { get; private set; }
        public int Hieght { get; private set; }
        public int Weight { get; private set; }

        public Criminal(Random random)
        {
            List<string> names = new List<string> { "Max", "John", "George", "Leon", "Boris", "David" };
            List<string> nationality = new List<string> { "American", "Englishman", "Frenchman", "German" };
            List<bool> isConvicted = new List<bool> { true, false };
            int maxHeight = 200;
            int minHeight = 140;
            int maxWeighth = 120;
            int minWeight = 60;

            Initials = names[random.Next(0, names.Count)];
            Nationality = nationality[random.Next(0, nationality.Count)];
            IsConvicted = isConvicted[random.Next(0, isConvicted.Count)];
            Hieght = random.Next(minHeight, maxHeight);
            Weight = random.Next(minWeight, maxWeighth);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {Initials}, Национальность - {Nationality}, Осужден - {IsConvicted}, Рост - {Hieght}см, Вес - {Weight}кг");
        }
    }
}
