using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork47
{
    class Program
    {
        static void Main(string[] args)
        {
            Platoon firstCountryPlatoon = new Platoon(new List<Soldier>(), 1);
            Platoon secondCountryPlatoon = new Platoon(new List<Soldier>(), 2);
            Battlefield battlefield = new Battlefield(firstCountryPlatoon, secondCountryPlatoon);

            battlefield.StartBattle();
        }
    }

    class Battlefield
    {
        private Platoon _firstPlatoon;
        private Platoon _secondPlatoon;

        public Battlefield(Platoon firstPlatoon, Platoon secondPlatoon)
        {
            _firstPlatoon = firstPlatoon;
            _secondPlatoon = secondPlatoon;
        }

        public void StartBattle()
        {
            _firstPlatoon.FillPlatoon();
            _secondPlatoon.FillPlatoon();
            _firstPlatoon.ShowInfo();
            Console.ReadKey();
            Console.Clear();
            _secondPlatoon.ShowInfo();
            Console.ReadKey();
            Console.Clear();

            while (_firstPlatoon.SoldiersCount > 0 && _secondPlatoon.SoldiersCount > 0)
            {
                for (int i = 0; i < _firstPlatoon.SoldiersCount; i++)
                {
                    for (int j = 0; j < _secondPlatoon.SoldiersCount; j++)
                    {
                        if (i < _firstPlatoon.SoldiersCount && j < _secondPlatoon.SoldiersCount)
                        {
                            _firstPlatoon.ReturnSoldier(i).GetDamage(_secondPlatoon.ReturnSoldier(j).Attack());
                            _secondPlatoon.ReturnSoldier(j).GetDamage(_firstPlatoon.ReturnSoldier(i).Attack());

                            _firstPlatoon.RemoveTrooper();
                            _secondPlatoon.RemoveTrooper();
                        }
                    }
                }

                _firstPlatoon.ShowCurrentSrats();
                Console.WriteLine();
                _secondPlatoon.ShowCurrentSrats();

                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"В первом взводе осталось {_firstPlatoon.SoldiersCount}");
            Console.WriteLine($"Во втором взводе осталось {_secondPlatoon.SoldiersCount}");
        }
    }

    class Platoon
    {
        private List<Soldier> _platoon;
        private int _number;

        public int SoldiersCount => _platoon.Count;

        public Platoon(List<Soldier> platoon, int number)
        {
            _platoon = platoon;
            _number = number;
        }

        public void FillPlatoon()
        {
            bool isCorrectInput = false;

            while (isCorrectInput == false)
            {
                Console.WriteLine($"Вдите количество войск для взвода {_number}");
                isCorrectInput = (int.TryParse(Console.ReadLine(), out int numberOfSoldiers));

                if (isCorrectInput)
                {
                    Troops allTroops = new Troops(numberOfSoldiers);
                    IReadOnlyList<Soldier> tempListSoldiers = allTroops.Create();

                    for (int i = 0; i < numberOfSoldiers; i++)
                    {
                        _platoon.Add(tempListSoldiers[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Вы допустили ошибку при вводе, попробуйте снова");
                    continue;
                }
            }

            Console.Clear();
        }

        public Soldier ReturnSoldier(int number)
        {
            return _platoon[number];
        }

        public void RemoveTrooper()
        {
            foreach (var soldier in _platoon.ToArray())
            {
                if (soldier.CurrentHealth <= 0)
                {
                    _platoon.Remove(soldier);
                    continue;
                }
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Во взводе номер {_number} находятся:\n");

            foreach (var soldier in _platoon)
            {
                soldier.ShowInfo();
            }
        }

        public void ShowCurrentSrats()
        {
            Console.WriteLine($"Текущие показатели взвода номер {_number}:\n");

            foreach (var soldier in _platoon)
            {
                Console.WriteLine($"У солдата {soldier.CurrentTroopType} здоровье равно {soldier.CurrentHealth}");
            }
        }
    }

    class Troops
    {
        private int _numberOfSoldiers;
        private int _soldiersTypeCount = 3;

        public Troops(int numberOfSoldiers)
        {
            _numberOfSoldiers = numberOfSoldiers;
        }

        public IReadOnlyList<Soldier> Create()
        {
            Random random = new Random();
            List<Soldier> soldiers = new List<Soldier>();

            for (int i = 0; i < _numberOfSoldiers; i++)
            {
                switch (random.Next(0, _soldiersTypeCount))
                {
                    case 0:
                        soldiers.Add(new StormTrooper(random));
                        break;

                    case 1:
                        soldiers.Add(new Sniper(random));
                        break;

                    case 2:
                        soldiers.Add(new Armored(random));
                        break;
                }
            }

            return soldiers;
        }
    }

    abstract class Soldier
    {
        protected int Health;
        protected int MaxHealth;
        protected int MinHealth;
        protected int Damage;
        protected int MaxDamage;
        protected int MinDamage;
        protected int Armor;
        protected int MaxArmor;
        protected int MinArmor;
        protected string TroopType;
        protected string Description;

        public int CurrentHealth => Health;
        public string CurrentTroopType => TroopType;

        public abstract void GetDamage(int damage);
        public abstract int Attack();
        public void ShowInfo()
        {
            Console.WriteLine($"Тип войск: {TroopType}, урон: {Damage}, здоровье: {Health}, броня: {Armor}\nОписание: {Description}");
        }
    }

    class StormTrooper : Soldier
    {
        public StormTrooper(Random random)
        {
            MaxHealth = 150;
            MinHealth = 100;
            MaxDamage = 40;
            MinDamage = 30;
            MaxArmor = 100;
            MinArmor = 80;

            Health = random.Next(MinHealth, MaxHealth);
            Damage = random.Next(MinDamage, MaxDamage);
            Armor = random.Next(MinArmor, MaxArmor);
            TroopType = "Штурмовик";
            Description = "Обычный боец, имеет средние характеристики";
        }

        public override int Attack()
        {
            return Damage;
        }


        public override void GetDamage(int damage)
        {
            if (Armor > 0)
                Armor -= damage;
            else
                Health -= damage;
        }
    }

    class Sniper : Soldier
    {
        public Sniper(Random random)
        {
            MaxHealth = 100;
            MinHealth = 80;
            MaxDamage = 80;
            MinDamage = 70;
            MaxArmor = 70;
            MinArmor = 60;

            Health = random.Next(MinHealth, MaxHealth);
            Damage = random.Next(MinDamage, MaxDamage);
            Armor = random.Next(MinArmor, MaxArmor);
            TroopType = "Снайпер";
            Description = "Имеет достаточно большой урон, но периодически промахивается";
        }

        public override int Attack()
        {
            Random random = new Random();
            int missValue = 0;
            int hitValue = 2;

            if (random.Next(missValue, hitValue) == missValue)
                return Damage;
            else
                return missValue;
        }

        public override void GetDamage(int damage)
        {
            if (Armor > 0)
                Armor -= damage;
            else
                Health -= damage;
        }
    }

    class Armored : Soldier
    {
        public Armored(Random random)
        {
            MaxHealth = 200;
            MinHealth = 150;
            MaxDamage = 30;
            MinDamage = 20;
            MaxArmor = 200;
            MinArmor = 150;

            Health = random.Next(MinHealth, MaxHealth);
            Damage = random.Next(MinDamage, MaxDamage);
            Armor = random.Next(MinArmor, MaxArmor);
            TroopType = "Бронированный";
            Description = "Имеет большие значения здоровья и брони, но небольшой урон";
        }

        public override int Attack()
        {
            return Damage;
        }

        public override void GetDamage(int damage)
        {
            if (Armor > 0)
                Armor -= damage;
            else
                Health -= damage;
        }
    }
}
