using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork48
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateAquarium();
        }

        static void CreateAquarium()
        {
            bool isCorrectInput;

            Console.WriteLine("Введите желаемую вместимость аквариума");
            isCorrectInput = int.TryParse(Console.ReadLine(), out int maxCopacity);

            if (isCorrectInput)
            {
                Console.WriteLine("Введите кличество рыб, которое хотите заселить");
                isCorrectInput = int.TryParse(Console.ReadLine(), out int numberOfFish);

                if (isCorrectInput)
                {
                    Aquarium aquarium = new Aquarium(numberOfFish, maxCopacity);

                    aquarium.Start();
                }
                else
                {
                    Console.WriteLine("Упс, что-то пошло не так...");
                }
            }
            else
            {
                Console.WriteLine("Упс, что-то пошло не так...");
            }
        }
    }

    class Aquarium
    {
        private int _numberOfFish;
        private int _maxCapacity;
        private List<Fish> _allFish;

        public Aquarium(int numberOfFish, int maxCapacity)
        {
            _numberOfFish = numberOfFish;
            _maxCapacity = maxCapacity;
        }

        public void Start()
        {
            const string AddFish = "add";
            const string RemoveDeadFish = "removedead";
            const string RemoveFish = "remove";
            const string ExitCommand = "exit";
            string userInput = null;

            Create();

            while (userInput != ExitCommand)
            {
                ShowAllFish();

                Console.WriteLine($"Вам доступны следующие команды\n" +
                    $"{AddFish} - добавить случайную рыбу\n" +
                    $"{RemoveDeadFish} - убрать всех мертвых рыб\n" +
                    $"{RemoveFish} - убрать рыбу по индексу\n" +
                    $"{ExitCommand} - Выйти\n" +
                    $"Enter - пропустить год\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddFish:
                        this.AddFish();
                        break;

                    case RemoveDeadFish:
                        this.RemoveDeadFish();
                        break;

                    case RemoveFish:
                        this.RemoveFish();
                        break;

                    case ExitCommand:
                        break;

                    default:
                        SkipYear();
                        break;
                }
            }
        }

        private void Create()
        {
            Random random = new Random();
            _allFish = new List<Fish>(_maxCapacity);

            if (_allFish.Capacity >= _numberOfFish)
            {
                for (int i = 0; i < _numberOfFish; i++)
                {
                    _allFish.Add(new Fish(random));
                }
            }
            else
            {
                Console.WriteLine($"Для всех рыб нехватило места, добавлено {_maxCapacity} рыб");

                for (int i = 0; i < _maxCapacity; i++)
                {
                    _allFish.Add(new Fish(random));
                }
            }
        }

        private void ShowAllFish()
        {
            Console.WriteLine("В аквариуме ссейчас находятся:\n");
            for (int i = 0; i < _allFish.Count; i++)
            {
                _allFish[i].ShowInfo(i);
            }
            Console.WriteLine();
        }

        private void RemoveDeadFish()
        {
            foreach (var fish in _allFish.ToArray())
            {
                if (fish.IsDead == true)
                    _allFish.Remove(fish);
            }
        }

        private void RemoveFish()
        {
            Console.WriteLine("Введите номер рыбы, которую хотите удалить");
            bool isCorrectInput = int.TryParse(Console.ReadLine(), out int number);

            if (isCorrectInput)
            {
                if (number >= 0 && number < _allFish.Count)
                    _allFish.RemoveAt(number);
                else
                    Console.WriteLine("Рыбы с таким индексом нет");
            }
            else
            {
                Console.WriteLine("Упс, что-то пошло не так...");
            }

        }

        private void AddFish()
        {
            if (_allFish.Count < _allFish.Capacity)
                _allFish.Add(new Fish(new Random()));
            else
                Console.WriteLine("В аквариуме уже максимальное число рыб");
        }

        private void SkipYear()
        {
            foreach (var fish in _allFish)
            {
                fish.MakeOld();
            }

            Console.Clear();
        }
    }

    class Fish
    {
        private int _age;
        private int _deathAge;

        public bool IsDead => _age >= _deathAge;

        public int Age => _age;

        public Fish(Random random)
        {
            int maxAge = 5;
            int minAge = 1;
            int maxDeathAge = 12;
            int minDeathAge = 8;

            _age = random.Next(minAge, maxAge);
            _deathAge = random.Next(minDeathAge, maxDeathAge);
        }

        public void ShowInfo(int number)
        {
            if (IsDead == false)
                Console.WriteLine($"Рыба {number} - {_age} лет");
            else
                Console.WriteLine($"Рыба {number} - умерла");
        }

        public void MakeOld()
        {
            _age++;
        }
    }
}
