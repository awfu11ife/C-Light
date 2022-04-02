using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork20
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = { { 2, 1, 8, 5 }, { 4, 6, 9, 1 }, { 5, 9, 7, 8 } };
            int stringNumber = 2;
            int columnNumber = 1;
            int sum = 0;
            int product = 1;

            Console.WriteLine("Массив:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sum += array[stringNumber, i];
            }

            Console.WriteLine($"Сумма второй строки (если считать с 0) равна {sum}");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                product = product * array[i, columnNumber];
            }

            Console.WriteLine($"Произведение первого столбца (если считать с 0) равно {product}");
        }
    }
}
