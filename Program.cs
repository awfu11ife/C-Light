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
            string symbolsString = null;
            char usersSymbol;

            Console.WriteLine("Введите своё имя");
            usersName = Console.ReadLine();
            Console.WriteLine("Введите любой символ");
            usersSymbol = Convert.ToChar(Console.ReadLine());

            Console.Clear();

            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < usersName.Length + extraCharactersNumber; i++)
            {
                symbolsString += usersSymbol;
            }

            Console.WriteLine(symbolsString);
            Console.WriteLine(usersSymbol + usersName + usersSymbol);
            Console.WriteLine(symbolsString);
        }
    }
}
