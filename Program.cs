using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork30
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isParsed = false;

            Console.WriteLine("Здравствуйте!");

            while(!isParsed)
            {
                Console.WriteLine("Ввести число");
                isParsed = ParseString(Console.ReadLine());
            }
        }

        static bool ParseString(string uesrInput)
        {
            int number;

            bool success = int.TryParse(uesrInput, out number);

            if (success)
            {
                Console.WriteLine($"Удивительно! У вас получилось ввести число! Это чило {number}");
            }
            else
            {
                Console.WriteLine("К сожалению, это не число... Попробуйте ещё раз");
            }

            return success;
        }
    }
}
