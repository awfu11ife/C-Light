using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork53
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadOnlyList<string> diseases = new List<string> { "Простуда", "Ангина", "Грипп", "Пневмония" };

            StartWork(diseases, 20);
        }

        static void StartWork(IReadOnlyList<string> deseases, int numberOfPatients)
        {
            const string ShowAll = "showall";
            const string ShowWithSelectedDisease = "bydisease";
            const string SortByAge = "byage";
            const string SortByName = "byname";
            const string ExitCommand = "exit";
            string userInput = null;
            DataBase dataBase = new DataBase(deseases, numberOfPatients);

            Console.WriteLine("Это база данных с вашими пациентами");

            while (userInput != ExitCommand)
            {
                Console.WriteLine($"Вам доступны следующие команды:\n" +
                    $"{ShowAll} - показать всех пациентов\n" +
                    $"{ShowWithSelectedDisease} - показать всех с выбранной болезнью\n" +
                    $"{SortByAge} - отсортировать по возрасту\n" +
                    $"{SortByName} - отсортировать по имени\n" +
                    $"{ExitCommand} - выйти\n");
                Console.WriteLine("Введите желаемую команду");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAll:
                        dataBase.ShowAll();
                        break;

                    case ShowWithSelectedDisease:
                        dataBase.ShowWithSelectedDisease();
                        break;

                    case SortByAge:
                        dataBase.SortByAge();
                        break;

                    case SortByName:
                        dataBase.SortByName();
                        break;

                    case ExitCommand:
                        break;

                    default:
                        Console.WriteLine("Такой команды нет...\n");
                        break;
                }
            }
        }
    }

    class DataBase
    {
        private List<Patient> _allPatients = new List<Patient>();
        private List<string> _diseases = new List<string>();

        public DataBase(IReadOnlyList<string> diseases, int numberOfPatients)
        {
            _diseases = (List<string>)diseases;
            Create(numberOfPatients);
        }

        public void ShowAll()
        {
            Console.WriteLine("Сейчас вы лечите следующих пациентов:\n");

            foreach (var patient in _allPatients)
            {
                patient.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void ShowWithSelectedDisease()
        {
            Console.WriteLine("Введите название болезни");
            string userInput = Console.ReadLine();

            if (_diseases.Contains(userInput))
            {
                var sortedPatients = _allPatients.Where(patient => patient.Disease == userInput);

                foreach (var patient in sortedPatients)
                {
                    patient.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Такой болезни нет");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void SortByAge()
        {
            var sortedPatients = _allPatients.OrderBy(player => player.Age);
            Console.WriteLine("Список, отсортированный по возрасту:\n");

            foreach (var patient in sortedPatients)
            {
                patient.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void SortByName()
        {
            var sortedPatients = _allPatients.OrderBy(player => player.Name);
            Console.WriteLine("Список, отсортированный по именам:\n");

            foreach (var patient in sortedPatients)
            {
                patient.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void Create(int number)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                _allPatients.Add(new Patient(_diseases, random));
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public string Disease { get; private set; }
        public int Age { get; private set; }

        public Patient(IReadOnlyList<string> diseases, Random random)
        {
            List<string> names = new List<string> { "Max", "John", "George", "Leon", "Boris", "David" };
            int maxAge = 70;
            int minAge = 18;

            Name = names[random.Next(0, names.Count)];
            Disease = diseases[random.Next(0, diseases.Count)];
            Age = random.Next(minAge, maxAge);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Пациент по имени {Name}, полных лет - {Age}, заболевание - {Disease}");
        }
    }
}
