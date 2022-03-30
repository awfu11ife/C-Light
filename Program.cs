using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16
{
    class Program
    {
        static void Main(string[] args)
        {
            int randomNumber;
            int currentNumber;
            int multiplesNumber = 0;
            int minValue = 1;
            int maxValue = 27;
            int lowerRangeLimit = 100;
            int upperRangeLimit = 999;
            Random random = new Random();

            randomNumber = random.Next(minValue, maxValue + 1);
            Console.WriteLine($"Рандомное число - {randomNumber}\n");

            for (int i = lowerRangeLimit; i <= upperRangeLimit; i++)
            {
                currentNumber = i;

                while (currentNumber >= 0)
                {
                    currentNumber -= randomNumber;

                    if (currentNumber == 0)
                    {
                        multiplesNumber++;
                        Console.WriteLine(i);
                    }
                }
            }
            Console.WriteLine($"\nВсего кратных чисел - {multiplesNumber}");
        }
    }
}
