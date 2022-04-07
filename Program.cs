using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork32
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Shuffle(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }

        static void Shuffle(int[] numbers)
        {
            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                int tempNumber = numbers[i];
                int randomIndex = random.Next(0, numbers.Length);
                numbers[i] = numbers[randomIndex];
                numbers[randomIndex] = tempNumber;
            }
        }
    }
}
