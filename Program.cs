using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork56
{
    class Program
    {
        static void Main(string[] args)
        {
            Platoon platoon = new Platoon(20);

            platoon.ShowAllSoldiers();
            platoon.ShowSoldiersParameters();
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Platoon(int number)
        {
            Create(number);
        }

        public void ShowAllSoldiers()
        {
            Console.WriteLine("Все солдаты:\n");

            foreach (var soldier in _soldiers)
            {
                soldier.ShowInfo();
            }
        }

        public void ShowSoldiersParameters()
        {
            var soldiersParameters = _soldiers.Select(soldier => new { Name = soldier.Name, Rank = soldier.Rank });
            Console.WriteLine("\nПараметры солдат:\n");

            foreach (var soldier in soldiersParameters)
            {
                Console.WriteLine($"Солдат {soldier.Name} имеет звание {soldier.Rank}");
            }
        }

        private void Create(int number)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                _soldiers.Add(new Soldier(random));
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Ammunition { get; private set; }
        public string Rank { get; private set; }
        public int ServiceTerm { get; private set; }

        public Soldier(Random random)
        {
            List<string> names = new List<string> { "Max", "John", "George", "Leon", "Boris", "David" };
            List<string> ammunition = new List<string> { "AKM", "M249", "M416", "MP5" };
            List<string> ranks = new List<string> { "Рядовой", "Лейтенант", "Майор", "Полковник" };
            int maxServiceTerm = 48;
            int minServiceTerm = 4;

            Name = names[random.Next(0, names.Count)];
            Ammunition = ammunition[random.Next(0, ammunition.Count)];
            Rank = ranks[random.Next(0, ranks.Count)];
            ServiceTerm = random.Next(minServiceTerm, maxServiceTerm);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Служащий по имени {Name} из вооружения имеет {Ammunition}, дослужился до звания {Rank} за {ServiceTerm} месяцев службы");
        }
    }
}
