using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork45
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fighter> fighters = new List<Fighter>() { new BoomerMan(300, 50, "Jack"), new Mathematican(300, 2, "Tom"),  new Randomer(200, "Mike"), new Returner(200, 15, "John"), new Dormouse(100, 60, 100, "Jason")};

            StartFignt(SelectFighters(fighters));
        }

        static List<Fighter> SelectFighters(List<Fighter> fighters)
        {
            List<Fighter> returnFighters = new List<Fighter>(0);
            int number = 0;
            int maxNumberOfFighters = 2;
            bool isCorrectInput;

            while (returnFighters.Count < maxNumberOfFighters)
            {
                foreach (var fighter in fighters)
                {
                    Console.Write($"{number} - ");
                    fighter.ShowInfo();
                    number++;
                }


                Console.WriteLine("Введите номер желаемого бойца");
                isCorrectInput = int.TryParse(Console.ReadLine(), out int numberOfFighter);

                if (isCorrectInput == true && numberOfFighter < fighters.Count)
                {
                    returnFighters.Add(fighters[numberOfFighter]);
                    fighters.RemoveAt(numberOfFighter);
                    Console.WriteLine("Боец выбран");
                }
                else
                {
                    Console.WriteLine("Такого бойца нет");
                }

                number = 0;
                Console.Clear();
            }

            return returnFighters;
        }

        static void StartFignt(List<Fighter> selectedFighters)
        {
            while (selectedFighters[0].NowHealth > 0 && selectedFighters[1].NowHealth > 0)
            {
                int firstFighterDamage = selectedFighters[0].Attack();
                int secondFighterDamage = selectedFighters[1].Attack();
                selectedFighters[0].GetDamage(secondFighterDamage);
                selectedFighters[1].GetDamage(firstFighterDamage);
            }

            if (selectedFighters[0].NowHealth <= 0)
            {
                Console.WriteLine($"Победил {selectedFighters[1].FighterName}");
            }
            else
            {
                Console.WriteLine($"Победил {selectedFighters[0].FighterName}");
            }
        }
    }

    abstract class Fighter
    {
        protected int Health;
        protected int Damage;
        protected int Armor;
        protected string Name;
        protected string Description;

        public string FighterName => Name;
        public int NowHealth => Health;

        abstract public int Attack();

        abstract public void GetDamage(int damage);

        public void ShowInfo()
        {
            Console.WriteLine($"Боец {Name} имеет следующие характеристики: урон - {Damage}, здоровье - {Health}, броня -  {Armor}\n" +
                $"Описание: {Description}");
        }

        protected void ShowCurrentStats()
        {
            Console.WriteLine($"У {Name} сейчас {Health} здоровья и  {Armor} единиц брони");
        }
    }

    class BoomerMan : Fighter
    {
        public BoomerMan(int health, int damage, string name)
        {
            Health = health;
            Damage = damage;
            Name = name;
            Armor = 0;
            Description = "С шансом 50% наносит урон х2, броня отсутствует";
        }

        public override int Attack()
        {
            int maxValue = 2;
            int minValue = 0;
            int increase = 2;
            Random random = new Random();
            int chance = random.Next(minValue, maxValue);

            if (chance == 1)
            {
                return Damage * increase;
            }
            else
            {
                return Damage;
            }
        }

        public override void GetDamage(int damage)
        {
            Health -= damage;
            ShowCurrentStats();
        }
    }

    class Mathematican : Fighter
    {
        public Mathematican(int health, int damage, string name)
        {
            Health = health;
            Damage = damage;
            Name = name;
            Armor = 0;
            Description = "С кажной атакой возводит свой урон в степень, не имеет брони";
        }

        public override int Attack()
        {
            int NowDamage = Damage;
            return NowDamage * Damage;
        }

        public override void GetDamage(int damage)
        {
            Health -= damage;
            ShowCurrentStats();
        }
    }

    class Randomer : Fighter
    {
        private int _maxDamage = 31;
        private int _minDamage = 10;
        public Randomer(int health, string name)
        {
            Health = health;
            Name = name;
            Description = $"Наносит рандомный урон от {_minDamage} до {_maxDamage - 1} и восстанавливает соответствующее количество здоровья";
        }

        public override int Attack()
        {
            Random random = new Random();
            int randoNumber = random.Next(_minDamage, _maxDamage);

            Health += randoNumber;
            return randoNumber;

        }

        public override void GetDamage(int damage)
        {
            Health -= damage;
            ShowCurrentStats();
        }
    }

    class Returner : Fighter
    {
        private int _takenDamage = 0;
        private int _coefficient = 2;

        public Returner(int health, int armor, string name)
        {
            Health = health;
            Damage = 0000;
            Name = name;
            Armor = 0;
            Description = $"Возвращает полученный урон в двойном размере, армор отсутствует";
        }

        public override int Attack()
        {
            return _takenDamage * _coefficient;
        }

        public override void GetDamage(int damage)
        {
            Health -= damage;
            _takenDamage = damage;
            ShowCurrentStats();
        }
    }

    class Dormouse : Fighter
    {
        private int _requiredHealth = 50;
        private int _minHealth = 100;
        private int _nullDamage = 0;

        public Dormouse(int health, int damage, int armor, string name)
        {
            if (health > _requiredHealth)
                Health = health;
            else
                Health = _minHealth;

            Damage = damage;
            Name = name;
            Armor = armor;
            Description = $"Пока его здоровье больше {_requiredHealth} он будет спать";
        }


        public override int Attack()
        {
            if (Health <= _requiredHealth)
                return Damage;
            else
                return _nullDamage;
        }

        public override void GetDamage(int damage)
        {
            if (Armor > 0)
                Armor -= damage;
            else
                Health -= damage;
            ShowCurrentStats();
        }
    }
}
