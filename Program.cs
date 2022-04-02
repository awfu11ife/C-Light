using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork23
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            const string ExitCommand = "exit";
            const string SumCommand = "sum";
            string userInput = null;

            while(userInput != ExitCommand)
            {
                Console.WriteLine($"Вам доступны следующие команды:\n" +
                    $"Ввести любое число - добавить число в массив\n" +
                    $"{SumCommand} - суммировать все числа массива\n" +
                    $"{ExitCommand} - завершить программу\n");
                Console.WriteLine("Введите желаемую команду");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case SumCommand:
                        int sum = 0;
                        for (int i = 0; i < array.Length; i++)
                        {
                            sum += array[i];
                        }

                        Console.WriteLine($"Сумма равна - {sum}\n");
                        break;

                    case ExitCommand:
                        break;

                    default:
                        int[] tempArray = new int[array.Length + 1];

                        for (int i = 0; i < array.Length; i++)
                        {
                            tempArray[i] = array[i];
                        }

                        tempArray[tempArray.Length - 1] = Convert.ToInt32(userInput);
                        array = tempArray;
                        break;
                }
            }
        }
    }
}
