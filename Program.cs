using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork25
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[15];
            int maxValue = 10;
            int minValue = 1;
            Random random = new Random();

            Console.Write("Массив: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write($"{array[i]} ");
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int tempNumber = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempNumber;
                    }
                }
            }

            Console.Write("\nНовый массив: ");

            foreach (var number in array)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
