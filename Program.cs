using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork22
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            int sum = 0;
            int minArrayValue = 1;
            int maxArrayValue = 10;
            Random random = new Random();

            Console.Write("Массив:   ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minArrayValue, maxArrayValue);
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
            Console.Write("Максимумы:");

            if (array[0] > array[1])
                Console.Write($"{ array[0]} ");
            else
                Console.Write("  ");

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i - 1] && array[i] > array[i + 1])
                    Console.Write($"{array[i]} ");
                else
                    Console.Write("  ");
            }

            if (array[array.Length - 1] > array[array.Length - 2])
                Console.Write(array[array.Length - 1]);
            else
                Console.Write("  ");

            Console.WriteLine();
        }
    }
}
