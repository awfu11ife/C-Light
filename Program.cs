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
            string targetNationality;
            bool isCorrectInput;
            List<string> userInput = new List<string>(4);
            List<int> parsedUserInput = new List<int>();

            Console.WriteLine("Введите максимальный и минимальный рост, максимальный и минимальный вес");

            for (int i = 0; i < userInput.Capacity; i++)
            {
                userInput.Add(Console.ReadLine());
            }

            for (int i = 0; i < userInput.Count; i++)
            {
                isCorrectInput = int.TryParse(userInput[i], out int currentParameter);

                if (isCorrectInput)
                {
                    parsedUserInput.Add(currentParameter);
                }
                else
                {
                    Console.WriteLine("Упс, что-то пошло не так....");
                }
            }

            Console.WriteLine("Введите национальность");
            targetNationality = Console.ReadLine();

            var filteredCriminals = _criminals.Where(criminal => criminal.Hieght <= parsedUserInput[0] && criminal.Hieght >= parsedUserInput[1] && criminal.Weight <= parsedUserInput[2] && criminal.Weight >= parsedUserInput[3] && criminal.Nationality == targetNationality && criminal.IsConvicted == false);

            foreach (var criminal in filteredCriminals)
            {
                criminal.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
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