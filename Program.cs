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
            Console.WriteLine("Здравствуйте!");
            Console.WriteLine($"Число - {TryGetNumber()}");
        }

        static int TryGetNumber()
        {
            int number = 0;
            bool success = false;

            while (success == false)
            {
                Console.WriteLine("Введите число");
                string uesrInput = Console.ReadLine();
                success = int.TryParse(uesrInput, out number);

                if (success == false)
                {
                    Console.WriteLine("К сожалению, это не число... Попробуйте ещё раз");
                }
                else
                {
                    Console.WriteLine("Удивительно! У вас получилось ввести число!");
                }
            }

            return number;
        }
    }
}
