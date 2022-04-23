using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork52
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadOnlyList<string> crimeTypes = new List<string> { "Антиправительственное", "Кражу", "Мошенничество", "Убийство" };
            Prison prison = new Prison(crimeTypes, 10);

            prison.ShowAllPrisoners();
            prison.Amnesty();
            prison.ShowAllPrisoners();
        }
    }

    class Prison
    {
        private List<Prisoner> _prisoners = new List<Prisoner>();
        private List<string> _crimeTypes = new List<string>();

        public Prison(IReadOnlyList<string> crimeTypes, int number)
        {
            _crimeTypes = (List<string>)crimeTypes;
            Create(number);
        }

        public void ShowAllPrisoners()
        {
            Console.WriteLine("В тюрьме сейчас сидят:\n");

            foreach (var prisoner in _prisoners)
            {
                prisoner.ShowInfo();
            }
        }

        public void Amnesty()
        {
            string amnestyCrimeType = "Антиправительственное";

            if (_crimeTypes.Contains(amnestyCrimeType))
            {
                _prisoners = _prisoners.Where(prisoner => prisoner.CrimeType != amnestyCrimeType).ToList();
                Console.WriteLine("\nПроизошла амнистия\n");
            }
            else
            {
                Console.WriteLine("Такого приступления нет");
            }
        }

        private void Create(int number)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                _prisoners.Add(new Prisoner(_crimeTypes, random));
            }
        }
    }

    class Prisoner
    {
        public string Name { get; private set; }
        public string CrimeType { get; private set; }

        public Prisoner(IReadOnlyList<string> crimeTypes, Random random)
        {
            List<string> names = new List<string> { "Max", "John", "George", "Leon", "Boris", "David" };

            Name = names[random.Next(0, names.Count)];
            CrimeType = crimeTypes[random.Next(0, crimeTypes.Count)];
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Заключенный по имени {Name} осужден за {CrimeType}");
        }
    }
}
