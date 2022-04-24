using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork57
{
    class Program
    {
        static void Main(string[] args)
        {
            Army army = new Army(10);

            Console.WriteLine("До перегруппировки:\n");
            army.ShowAll();
            Console.WriteLine("\nПосле перегруппировки\n");
            army.Regroup();
            army.ShowAll();
        }
    }

    class Army
    {
        private List<Soldier> _firstPlatoon = new List<Soldier>();
        private List<Soldier> _secondPlatoon = new List<Soldier>();

        public Army(int number)
        {
            FillPlatoon(_firstPlatoon, number);
            FillPlatoon(_secondPlatoon, number);
        }

        public void ShowAll()
        {
            Console.WriteLine("В первом взводе:\n");

            foreach (var soldier in _firstPlatoon)
            {
                Console.WriteLine(soldier.Surname);
            }

            Console.WriteLine("\nВо втором взводе:\n");

            foreach (var soldier in _secondPlatoon)
            {
                Console.WriteLine(soldier.Surname);
            }
        }

        public void Regroup()
        {
            string firstLetter = "Б";

            _secondPlatoon = _secondPlatoon.Union(_firstPlatoon.Where(soldier => soldier.Surname.ToUpper().StartsWith(firstLetter))).ToList();
            _firstPlatoon = _firstPlatoon.Where(soldier => soldier.Surname.ToUpper().StartsWith(firstLetter) == false).ToList();
        }

        private void FillPlatoon(List<Soldier> platoon, int number)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                platoon.Add(new Soldier(random));
            }
        }
    }

    class Soldier
    {
        public string Surname { get; private set; }

        public Soldier(Random random)
        {
            List<string> surnames = new List<string> { "Ковалев", "Безруков", "Баранов", "Веселов", "Семенов" };

            Surname = surnames[random.Next(0, surnames.Count)];
        }
    }
}
