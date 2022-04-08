using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork35
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = new List<int>();

            MakeChoice(numbersList);
        }

        static void MakeChoice(List<int> numbersList)
        {
            const string ExitCommand = "exit";
            const string SumCommand = "sum";
            string userInput = null;

            while (userInput != ExitCommand)
            {
                Console.WriteLine($"Вам доступны следующие команды:\n" +
                    $"Ввести любое число - добавить число в массив\n" +
                    $"{SumCommand} - суммировать все числа массива\n" +
                    $"{ExitCommand} - завершить программу\n");
                Console.WriteLine("Введите желаемую команду");
                userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case SumCommand:
                        SumNumbersInList(numbersList);
                        break;

                    case ExitCommand:
                        break;

                    default:
                        AddNumberToList(numbersList, userInput);
                        break;
                }
            }
        }

        static void AddNumberToList(List<int> numbersList, string userInput)
        {
            int number;
            bool success = int.TryParse(userInput, out number);

            if (success == true)
            {
                numbersList.Add(number);
            }
            else
            {
                Console.WriteLine("К сожалению это не число");
            }
        }

        static void SumNumbersInList(List<int> numbersList)
        {
            int sum = 0;

            for (int i = 0; i < numbersList.Count; i++)
            {
                sum += numbersList[i];
            }

            Console.WriteLine($"Сумма равна - {sum}\n");
            sum = 0;
        }
    }
}
