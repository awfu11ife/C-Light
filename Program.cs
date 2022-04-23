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
            prison.Amnesty(crimeTypes);
            prison.ShowAllPrisoners();
        }
    }

    class Prison
    {
        private List<Prisoner> _prisoners = new List<Prisoner>();

        public Prison(IReadOnlyList<string> crimeTypes, int number)
        {
            Create(crimeTypes, number);
        }

        public void ShowAllPrisoners()
        {
            Console.WriteLine("В тюрьме сейчас сидят:\n");

            foreach (var prisoner in _prisoners)
            {
                prisoner.ShowInfo();
            }
        }

        public void Amnesty(IReadOnlyList<string> crimeTypes)
        {
            string amnestyCrimeType = "Антиправительственное";

            if (crimeTypes.Contains(amnestyCrimeType))
            {
                var amnestedPrisoners = _prisoners.Where(prisoner => prisoner.CrimeType == amnestyCrimeType);

                foreach (var prisoner in amnestedPrisoners.ToArray())
                {
                    _prisoners.Remove(prisoner);
                }

                Console.WriteLine("\nПроизошла амнистия\n");
            }
            else
            {
                Console.WriteLine("Такого приступления нет");
            }
        }

        private void Create(IReadOnlyList<string> crimeTypes, int number)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                _prisoners.Add(new Prisoner(crimeTypes, random));
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
