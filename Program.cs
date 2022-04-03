using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork24
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            int maxArrayLenght = 1;
            int currentMaxArrayLenght = 1;
            int numberInMaxArray = 0;
            int maxValue = 3;
            int minValue = 1;
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write($"{array[i]} ");
            }

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] == array[i - 1])
                {
                    currentMaxArrayLenght++;
                }
                else
                {
                    currentMaxArrayLenght = 1;
                }

                if (currentMaxArrayLenght >= maxArrayLenght)
                {
                    maxArrayLenght = currentMaxArrayLenght;
                    numberInMaxArray = array[i];
                }
            }

            Console.WriteLine($"\nMax Lenght = {maxArrayLenght} Number = {numberInMaxArray}");
        }
    }
}
