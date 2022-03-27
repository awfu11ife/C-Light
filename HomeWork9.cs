using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9
{
    class Program
    {
        static void Main(string[] args)
        {
            string stopWord = "exit";
            string usersWord = "";

            while (stopWord != usersWord)
            {
                Console.WriteLine("Программа выполняеся......");
                Console.WriteLine("Для продолжения нажмите Enter. Если вы вхотите завершить программу, введите 'exit'");
                usersWord = Console.ReadLine();
            }
        }
    }
}
