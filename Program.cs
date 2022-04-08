using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork36
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> workers = new Dictionary<string, string>();

            RunDictionary(workers);
        }

        static void RunDictionary(Dictionary<string, string> workers)
        {
            const string AddDossier = "add";
            const string DisplayAll = "displayall";
            const string Delete = "delete";
            const string Exit = "exit";
            string userInput = null;

            Console.WriteLine("Добро пожалвать в кадровый отдел компании\n");

            while (userInput != Exit)
            {
                Console.WriteLine($"Вы можете:\n" +
                    $"{AddDossier} - добавить досье\n" +
                    $"{DisplayAll} - вывести все досье\n" +
                    $"{Delete} - удалить досье\n" +
                    $"{Exit} - выйти\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddDossier:
                        AddDossiers(workers);
                        break;

                    case DisplayAll:
                        DisplayAllWorkers(workers);
                        break;

                    case Delete:
                        RemoveWorker(workers);
                        break;

                    case Exit:
                        break;

                    default:
                        Console.WriteLine("Мы не знаем такой команды");
                        break;
                }
            }
        }

        static void AddDossiers(Dictionary<string, string> workers)
        {
            Console.WriteLine("Введите ФИО работника");
            string userInputInitials = Console.ReadLine();
            if (workers.ContainsKey(userInputInitials) == false)
            {
                Console.WriteLine("Введите должность");
                string userInputPosition = Console.ReadLine();
                workers.Add(userInputInitials, userInputPosition);
                Console.Clear();
                Console.WriteLine("Работник добавлен\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такой работник уже есть\n");
            }
        }

        static void DisplayAllWorkers(Dictionary<string, string> workers)
        {
            Console.Clear();

            if (workers.Count > 0)
            {
                foreach (var worker in workers)
                {
                    Console.WriteLine($"{worker.Key} - {worker.Value}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("У вас пока нет работников\n");
            }
        }
        static void RemoveWorker(Dictionary<string, string> workers)
        {
            if (workers.Count > 0)
            {
                Console.WriteLine("Введите фамилию работника, которого хотите убрать");
                string userInput = Console.ReadLine();

                if (workers.ContainsKey(userInput))
                {
                    Console.Clear();
                    workers.Remove(userInput);
                    Console.WriteLine("Работник удален\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Такого работника нет\n");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("У вас пока нет работников\n");
            }
        }
    }
}

