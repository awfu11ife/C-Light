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
            string[] initials = new string[0];
            string[] position = new string[0];
            const string AddDossier = "add";
            const string DisplayAll = "displayall";
            const string Delete = "delete";
            const string Find = "find";
            const string Exit = "exit";
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
                        Console.WriteLine("Введите ФИО работника");
                        userInput = Console.ReadLine();
                        AddDossiers(ref initials, userInput);
                        Console.WriteLine("Ведите должность");
                        userInput = Console.ReadLine();
                        AddDossiers(ref position, userInput);
                        break;

                    case DisplayAll:
                        DisplayAllWorkers(initials, position);
                        Console.WriteLine();
                        break;

                    case Delete:
                        if (initials.Length > 0)
                        {
                            Console.WriteLine("Введите фамлию работника, которого хотите убрать");
                            userInput = Console.ReadLine();
                            RemoveWorker(ref initials, ref position, userInput);
                        }
                        else
                        {
                            Console.WriteLine("У вас пока нет сотрудников");
                        }
                        break;

                    case Find:
                        Console.WriteLine("Введите фамилию работника, которого хотите найти");
                        userInput = Console.ReadLine();
                        FindByName(initials, position, userInput);
                        break;

                    case Exit:
                        break;

                    default:
                        Console.WriteLine("Мы не знаем такой команды");
                        break;
                }
            }
        }

        static void AddDossiers(ref string[] workers, string userInput)
        {
            string[] tempArray = new string[workers.Length + 1];

            for (int i = 0; i < workers.Length; i++)
            {
                tempArray[i] = workers[i];
            }
            tempArray[tempArray.Length - 1] = userInput;
            workers = tempArray;
        }

        static void DisplayAllWorkers(string[] initials, string[] position)
        {
            for (int i = 0; i < initials.Length; i++)
            {
                Console.WriteLine($"{initials[i]} - {position[i]}");
            }
        }

        static void RemoveWorker(ref string[] initials, ref string[] position, string userInput)
        {
            int indexOfWorker = 0;
            string[] currentWorker;

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

            ResizeArray(ref initials, indexOfWorker);
            ResizeArray(ref position, indexOfWorker);
        }

        static void ResizeArray(ref string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
                tempArray[i] = array[i];

            for (int i = index + 1; i < array.Length; i++)
                tempArray[i - 1] = array[i];

            array = tempArray;
        }

        static void FindByName(string[] initials, string[] position, string userInput)
        {
            int indexOfWorker = 0;
            string[] currentWorker;

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
