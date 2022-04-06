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

            while(isParsed == false)
            {
                isParsed = ParseString();
            }
        }

        static bool ParseString()
        {
            int number;

            Console.WriteLine("Ввести число");
            string uesrInput = Console.ReadLine();
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
