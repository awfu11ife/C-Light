using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork14
{
    class Program
    {
        static void Main(string[] args)
        {
            int extraCharactersNumber = 2;
            string usersName;
            char usersSymbol;

            Console.WriteLine("Введите своё имя");
            usersName = Console.ReadLine();
            Console.WriteLine("Введите любой символ");
            usersSymbol = Convert.ToChar(Console.ReadLine());

            Console.Clear();

            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < usersName.Length + extraCharactersNumber; i++)
            {
                Console.Write(usersSymbol);
            }

            Console.WriteLine();
            Console.Write(usersSymbol + usersName + usersSymbol);
            Console.WriteLine();

            for (int i = 0; i < usersName.Length + extraCharactersNumber; i++)
            {
                Console.Write(usersSymbol);
            }
            Console.WriteLine();
        }
    }
}
