using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 2;
            int currenNumberPower = 2;
            int currentExponent = 1;
            int randomNumber;
            int lowerRangeLimit = 2;
            int upperRangeLimit = 100;
            Random random = new Random();

            randomNumber = random.Next(lowerRangeLimit, upperRangeLimit);

            while (currenNumberPower < randomNumber)
            {
                currenNumberPower = currenNumberPower * number;
                currentExponent++;
            }
            Console.WriteLine($"Рандомное число - {randomNumber}, Степень - {currentExponent}, Число в степени - {currenNumberPower}");
        }
    }
}
