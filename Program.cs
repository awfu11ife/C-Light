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

            Console.Write("Массив: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minArrayValue, maxArrayValue);
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i - 1] && array[i] > array[i + 1])
                    sum += array[i];
            }

            if (array[0] > array[1])
            {
                sum += array[0];
            }

            if (array[array.Length - 1] > array[array.Length - 2])
            {
                sum += array[array.Length - 1];
            }

            Console.WriteLine($"Сумма равна {sum}");
        }
    }
}
