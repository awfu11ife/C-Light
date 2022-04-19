using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork49
{
    class Program
    {
        static void Main(string[] args)
        {
            Aviary aviary = new Aviary(6);

            aviary.Show();
        }
    }

    class Zoo
    {

    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public Aviary (uint numberOfAnimals)
        {
            Create<Lion>(numberOfAnimals);
        }

        private void Create<T>(uint mumberOfAnimals) where T : Animal
        {
            for (uint i = 0; i < mumberOfAnimals; i++)
            {
                _animals.Add(new Animal(new Random()) as T);
            }
        }

        public void Show()
        {
            foreach (var item in _animals)
            {
                item.MakeNoise();
            }
        }
    }

    class Animal
    {
        public  string AnimalKind { get; protected set; }
        public string AnimalGender { get; protected set; }
        public string AnimalSound { get; protected set; }

        private List<string> AnimalGenderType = new List<string> { "мужской", "женский" };

        public Animal(Random random)
        {
            SetGender(random);
        } 

        public void MakeNoise()
        {
            Console.WriteLine(AnimalSound);
        }

        private void SetGender(Random random)
        {
            int numberOfGender = random.Next(0, AnimalGenderType.Count);
            AnimalGender = AnimalGenderType[numberOfGender];
        }
    }

    class Lion : Animal
    {
        public Lion() : base (new Random())
        {
            AnimalKind = "Лев";
            AnimalSound = "РррРрРрРРр";
        }
    }

    class Giraffe : Animal
    {
        public Giraffe() : base(new Random())
        {
            AnimalKind = "Жираф";
            AnimalSound = "*Звуки жирафов*";
        }
    }

    class Parrot : Animal
    {
        public Parrot() : base(new Random())
        {
            AnimalKind = "Попугай";
            AnimalSound = "Чирик-чирик";
        }
    }

    class Monkey : Animal
    {
        public Monkey() : base(new Random())
        {
            AnimalKind = "Обезьяна";
            AnimalSound = "*Крик обезьян*";
        }
    }
}
