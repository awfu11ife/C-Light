using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber;
            int minNumber = 0;
            int maxNumber = 101;
            int firstMultiple = 3;
            int secondMultiple = 5;
            int sum = 0;

            randomNumber = random.Next(minNumber, maxNumber);
            Console.WriteLine(randomNumber);

            for (int i = 0; i <= randomNumber; i++)
            {
                if (i % firstMultiple == 0 | i % secondMultiple == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
