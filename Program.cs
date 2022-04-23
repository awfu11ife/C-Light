using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork54
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase(30);
            dataBase.ShowAllPlayers();
            dataBase.TopByLevel(3);
            dataBase.TopByStrenght(3);
        }
    }

    class DataBase
    {
        private List<Player> _allPlayers = new List<Player>();

        public DataBase(int number)
        {
            Create(number);
        }

        public void ShowAllPlayers()
        {
            Console.WriteLine("В базе данных находятся следующие игроки:\n");

            foreach (var player in _allPlayers)
            {
                player.ShowInfo();
            }
        }

        public void TopByLevel(int numberOfPlaces)
        {
            var topByLevel = _allPlayers.OrderByDescending(player => player.Level).Take(numberOfPlaces);
            Console.WriteLine($"\nТоп {numberOfPlaces} игрока по уровню\n");

            foreach (var player in topByLevel)
            {
                player.ShowInfo();
            }
        }

        public void TopByStrenght(int numberOfPlaces)
        {
            var topByStrenght = _allPlayers.OrderByDescending(player => player.Strenght).Take(numberOfPlaces);
            Console.WriteLine($"\nТоп {numberOfPlaces} игрока по силе\n");

            foreach (var player in topByStrenght)
            {
                player.ShowInfo();
            }
        }

        private void Create(int number)
        {
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                _allPlayers.Add(new Player(random));
            } 
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Strenght { get; private set; }
        public int Level { get; private set; }

        public Player(Random random)
        {
            List<string> names = new List<string> { "Max", "John", "George", "Leon", "Boris", "David" };
            int maxStrenght = 500;
            int minStrenght = 100;
            int maxLevel = 100;
            int minLevel = 1;

            Name = names[random.Next(0, names.Count)];
            Strenght = random.Next(minStrenght, maxStrenght);
            Level = random.Next(minLevel, maxLevel);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"У игрока {Name} уровень - {Level} и сила - {Strenght}");
        }
    }
}
