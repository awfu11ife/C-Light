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
            
        }
    }

    class Battlefield
    {

    }

    class Platoon
    {
        private int _numberOfSoldiers;

        public Platoon(int numberOfSoldiers)
        {
            _numberOfSoldiers = numberOfSoldiers;
        } 

        public List<Soldier> Create()
        {
            Random random = new Random();
            List<Soldier> soldiers = new List<Soldier>();

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

        public abstract void GetDamage(int damage);
        public abstract int Attack();
        public void ShowInfo()
        {
            Console.WriteLine($"Тип войск: {TroopType}, урон: {Damage}, здоровье: {Health}, броня: {Armor}\nОписание: {Description}");
        }                     
    }

    class StormTrooper : Soldier
    {
        public StormTrooper()
        {
            MaxHealth = 150;
            MinHealth = 100;
            MaxDamage = 40;
            MinDamage = 30;
            MaxArmor = 100;
            MinArmor = 80;
            Random random = new Random();

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
        public Sniper()
        {
            MaxHealth = 100;
            MinHealth = 80;
            MaxDamage = 80;
            MinDamage = 70;
            MaxArmor = 70;
            MinArmor = 60;
            Random random = new Random();

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
        public Armored()
        {
            MaxHealth = 200;
            MinHealth = 150;
            MaxDamage = 30;
            MinDamage = 20;
            MaxArmor = 200;
            MinArmor = 150;
            Random random = new Random();

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
