using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Billy", 100, 20, 10);

            player.ShowInfo();
        }
    }

    class Player
    {
        private string _name;
        private int _health;
        private int _damage;
        private float _speed;

        public Player(string name, int health, int damage, float speed)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _speed = speed;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {_name}, жизни - {_health}, урон - {_damage}, скорость - {_speed}");
        }
    }
}
