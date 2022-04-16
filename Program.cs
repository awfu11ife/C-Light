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
            Battlefield battlefield = new Battlefield();
            battlefield.CreatePlatoon();
            battlefield.ShowInfo();
            battlefield.StartBattle();
        }
    }

    class Battlefield
    {
        private List<Soldier> firstContryPlatoon = new List<Soldier>();
        private List<Soldier> secondContryPlatoon = new List<Soldier>();

        public void CreatePlatoon()
        {
            bool isCorrectInput = false;

            while (isCorrectInput == false)
            {
                Console.WriteLine("Вдите количество войск, которое должно быть на поле боя, число дожно быть чётное");
                isCorrectInput = (int.TryParse(Console.ReadLine(), out int numberOfSoldiers) && numberOfSoldiers % 2 == 0);

                if (isCorrectInput)
                {
                    Platoon platoon = new Platoon(numberOfSoldiers);
                    List<Soldier> tempListSoldiers = platoon.Create();

                    for (int i = 0; i < numberOfSoldiers / 2; i++)
                    {
                        firstContryPlatoon.Add(tempListSoldiers[i]);
                    }

                    for (int i = numberOfSoldiers - 1; i >= numberOfSoldiers / 2; i--)
                    {
                        secondContryPlatoon.Add(tempListSoldiers[i]);
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

        public void ShowInfo()
        {
            Console.WriteLine("В первом взводе находятся:\n");

            foreach (var soldier in firstContryPlatoon)
            {
                soldier.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Во втором взводе находятся\n");

            foreach (var soldier in secondContryPlatoon)
            {
                soldier.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void StartBattle()
        {
            while (firstContryPlatoon.Count > 0 && secondContryPlatoon.Count > 0)
            {
                for (int i = 0; i < firstContryPlatoon.Count; i++)
                {
                    for (int j = 0; j < secondContryPlatoon.Count; j++)
                    {
                        if (i < firstContryPlatoon.Count && j < secondContryPlatoon.Count)
                        {
                            firstContryPlatoon[i].GetDamage(secondContryPlatoon[j].Attack());
                            secondContryPlatoon[j].GetDamage(firstContryPlatoon[i].Attack());

                            if (firstContryPlatoon[i].CurrentHealth <= 0)
                            {
                                firstContryPlatoon.RemoveAt(i);
                                continue;
                            }

                            if (secondContryPlatoon[j].CurrentHealth <= 0)
                            {
                                secondContryPlatoon.RemoveAt(j);
                                continue;
                            }
                        }
                    }
                }

                Console.WriteLine($"Текущие показатели первого взвода:\n");

                foreach (var soldier in firstContryPlatoon)
                {
                    Console.WriteLine($"Тип войск - {soldier.CurrentTroopType}, здоровье - {soldier.CurrentHealth}");
                }

                Console.WriteLine($"\nТекущие показатели вторго взвода:\n");

                foreach (var soldier in secondContryPlatoon)
                {
                    Console.WriteLine($"Тип войск - {soldier.CurrentTroopType}, здоровье - {soldier.CurrentHealth}");
                }

                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"В первом взводе осталось {firstContryPlatoon.Count}");
            Console.WriteLine($"Во втором взводе осталось {secondContryPlatoon.Count}");
        }
    }

    class Platoon
    {
        private int _numberOfSoldiers;
        private int _soldiersTypeCount = 3;

        public Platoon(int numberOfSoldiers)
        {
            _numberOfSoldiers = numberOfSoldiers;
        }

        public List<Soldier> Create()
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
            Description = "Имеет больгшие значения здоровья и брони, но небольшой урон";
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
