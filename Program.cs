using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28
{
    class Program
    {
        static void Main(string[] args)
        {
            const string AddDossier = "add";
            const string DisplayAll = "displayall";
            const string Delete = "delete";
            const string Find = "find";
            const string Exit = "exit";
            string[] initials = new string[0];
            string[] position = new string[0];
            string userInput = null;

            Console.WriteLine("Добро пожалвать в кадровый отдел компании");

            while (userInput != Exit)
            {
                Console.WriteLine($"\nВы можете:\n" +
                    $"{AddDossier} - добавить досье\n" +
                    $"{DisplayAll} - вывести все досье\n" +
                    $"{Delete} - удалить досье\n" +
                    $"{Find} - найти сотрудника по фамилии\n" +
                    $"{Exit} - выйти\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddDossier:
                        AddDossiers(ref initials, ref position);
                        break;

                    case DisplayAll:
                        DisplayAllWorkers(initials, position);
                        break;

                    case Delete:
                        RemoveWorker(ref initials, ref position);
                        break;

                    case Find:
                        FindByName(initials, position);
                        break;

                    case Exit:
                        break;

                    default:
                        Console.WriteLine("Мы не знаем такой команды");
                        break;
                }
            }
        }

        static void AddDossiers(ref string[] initials, ref string[] position)
        {
            Console.WriteLine("Введите ФИО работника");
            IncreaseArray(ref initials);
            Console.WriteLine("Введите должность");
            IncreaseArray(ref position);
        }

        static void IncreaseArray(ref string[] array)
        {
            string userInput = Console.ReadLine();
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - 1] = userInput;
            array = tempArray;
        }

        static void DisplayAllWorkers(string[] initials, string[] position)
        {
            for (int i = 0; i < initials.Length; i++)
            {
                Console.WriteLine($"{initials[i]} - {position[i]}");
            }
        }

        static void RemoveWorker(ref string[] initials, ref string[] position)
        {
            int indexOfWorker = 0;
            string[] currentWorker;
            string userInput;

            if (initials.Length > 0)
            {
                Console.WriteLine("Введите фамлию работника, которого хотите убрать");
                userInput = Console.ReadLine();

                for (int i = 0; i < initials.Length; i++)
                {
                    currentWorker = initials[i].Split();

                    for (int j = 0; j < currentWorker.Length; j++)
                    {
                        if (userInput == currentWorker[j])
                        {
                            indexOfWorker = i;
                            ReduseArray(ref initials, indexOfWorker);
                            ReduseArray(ref position, indexOfWorker);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Увас пока нет сотрудников");
            }
        }

        static void ReduseArray(ref string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
                tempArray[i] = array[i];

            for (int i = index + 1; i < array.Length; i++)
                tempArray[i - 1] = array[i];

            array = tempArray;
        }

        static void FindByName(string[] initials, string[] position)
        {
            int indexOfWorker = 0;
            string userInput;
            string[] currentWorker;

            Console.WriteLine("Введите фамилию работника, которого хотите найти");
            userInput = Console.ReadLine();

            for (int i = 0; i < initials.Length; i++)
            {
                currentWorker = initials[i].Split();

                for (int j = 0; j < currentWorker.Length; j++)
                {
                    if (userInput == currentWorker[j])
                    {
                        indexOfWorker = i;
                    }
                }
            }
            Console.WriteLine($"{initials[indexOfWorker]} - {position[indexOfWorker]}");
        }
    }
}
