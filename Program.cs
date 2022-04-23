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
            Prison prison = new Prison(10);

            prison.ShowAllPrisoners();
            prison.ShowPrisonersAfterAmnesty();
        }
    }

    class Prison
    {
        private List<Prisoner> _prisoners = new List<Prisoner>();

        public Prison(int number)
        {
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

        public void ShowPrisonersAfterAmnesty()
        {
            var amnestedPrisoners = _prisoners.Where(prisoner => prisoner.CrimeType == CrimeTypes.Антиправительственное);
            Console.WriteLine("\nПосле амнистии в тюрьме остались:\n");

            foreach (var prisoner in amnestedPrisoners.ToArray())
            {
                _prisoners.Remove(prisoner);
            }

            foreach (var prisoner in _prisoners)
            {
                prisoner.ShowInfo();
            }
        }

        private void Create(int number)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                _prisoners.Add(new Prisoner(random));
            }
        }
    }

    class Prisoner
    {
        public string Name { get; private set; }
        public CrimeTypes CrimeType { get; private set; }

        public Prisoner(Random random)
        {
            List<string> names = new List<string> { "Max", "John", "George", "Leon", "Boris", "David" };
            List<CrimeTypes> crimeTypes = new List<CrimeTypes> { CrimeTypes.Антиправительственное, CrimeTypes.Кражу, CrimeTypes.Мошенничество, CrimeTypes.Убийство };

            Name = names[random.Next(0, names.Count)];
            CrimeType = crimeTypes[random.Next(0, crimeTypes.Count)];
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Заключенный по имени {Name} осужден за {CrimeType}");
        }
    }
    
    enum CrimeTypes
    {
        Антиправительственное,
        Кражу,
        Мошенничество,
        Убийство
    }
}
