using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork21
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[10, 10];
            int currentMaxElement = 0;
            int maxRandomValue = 101;
            int minRandomValue = 1;
            Random random = new Random();

            Console.WriteLine("Массив:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minRandomValue, maxRandomValue);
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (currentMaxElement < array[i, j])
                        currentMaxElement = array[i, j];
                }
            }

            Console.WriteLine($"\nМаксимальный элемент равен {currentMaxElement}");
            Console.WriteLine($"\nКонечный массив:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (currentMaxElement == array[i, j])
                        array[i, j] = 0;

                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
