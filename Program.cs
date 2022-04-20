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
            GoToZoo();
        }

        static void GoToZoo()
        {
            const int Exit = 10;
            int? userInput = null;
            bool isCorrectInput;
            Zoo zoo = new Zoo();

            Console.WriteLine("Добро пожаовать в наш зоопарк!\n");

            while (userInput != Exit)
            {
                zoo.ShowAllAviaries();
                Console.WriteLine($"{Exit} - уйти из зоопарка");
                Console.WriteLine("\nВведите номер вольера, к которому хотите подойти");

                isCorrectInput = int.TryParse(Console.ReadLine(), out int number);
                userInput = number;

                if (isCorrectInput)
                {
                    if (userInput != Exit)
                        zoo.ComeToAviary(number);
                    else
                        Console.WriteLine("До новых встреч!");
                }
                else
                {
                    Console.WriteLine("Упс, что-то пошло не так");
                }
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary> { new Aviary(10, AnimalType.Львы, AnimalSound.РрРрРррРр), new Aviary(8, AnimalType.Жирафы, AnimalSound.ЗвукиЖирафов), new Aviary(15, AnimalType.Попугаи, AnimalSound.ЧирикЧирик), new Aviary(4, AnimalType.Обезьяны, AnimalSound.КрикОбезьян) };

        public void ShowAllAviaries()
        {
            Console.WriteLine("У нас есть следующие вольеры:\n");

            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i} - В нем сидят {_aviaries[i].AnimalType}");
            }
        }

        public void ComeToAviary(int numberOfAviary)
        {
            if (numberOfAviary < _aviaries.Count && numberOfAviary >= 0)
            {
                _aviaries[numberOfAviary].ShowInfo();
            }
            else
            {
                Console.WriteLine("Упс, что-то пошло не так");
            }

            Console.ReadKey();
        }
    }

    class Aviary
    {
        private string _animalSound;
        private List<Animal> _animals = new List<Animal>();

        public string AnimalType { get; private set; }

        public Aviary(uint numberOfAnimals, Enum animalType, Enum animalSound)
        {
            AnimalType = animalType.ToString();
            _animalSound = animalSound.ToString();
            Create(numberOfAnimals);
        }

        public void ShowInfo()
        {
            int numberOfMaleIndividuals = 0;
            int numberOfFemaleIndividuals = 0;

            foreach (var animal in _animals)
            {
                if (animal.AnimalGender == Animal.Male)
                {
                    numberOfMaleIndividuals++;
                }
                else
                {
                    numberOfFemaleIndividuals++;
                }
            }

            Console.WriteLine($"В вольере находтся {numberOfMaleIndividuals} особей мужского пола и  {numberOfFemaleIndividuals} особей женского пола, они издают звук {_animalSound}");
        }

        private void Create(uint mumberOfAnimals)
        {
            Random random = new Random();

            for (uint i = 0; i < mumberOfAnimals; i++)
            {
                _animals.Add(new Animal(random, AnimalType, _animalSound));
            }
        }
    }

    class Animal
    {
        public const string Male = "Мужской";
        public const string Female = "Женский";

        public string AnimalType { get; protected set; }
        public string AnimalGender { get; protected set; }
        public string AnimalSound { get; protected set; }

        private List<string> _animalGenderType = new List<string> { Male, Female };

        public Animal(Random random, string animalType, string animalSound)
        {
            AnimalType = animalType;
            AnimalSound = animalSound;
            SetGender(random);
        }

        public void MakeNoise()
        {
            Console.WriteLine(AnimalSound);
        }

        private void SetGender(Random random)
        {
            int numberOfGender = random.Next(0, _animalGenderType.Count);
            AnimalGender = _animalGenderType[numberOfGender];
        }
    }

    enum AnimalType
    {
        Львы,
        Жирафы,
        Попугаи,
        Обезьяны
    }

    enum AnimalSound
    {
        РрРрРррРр,
        ЗвукиЖирафов,
        ЧирикЧирик,
        КрикОбезьян
    }
}
