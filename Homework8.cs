using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    class Program
    {
        static void Main(string[] args)
        {
            string usersMessage;
            int repetionsNumber;

            Console.WriteLine("Введите своё сообщение");
            usersMessage = Console.ReadLine();
            Console.WriteLine("Сколько раз вы хотите его вывести на экран?");
            repetionsNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < repetionsNumber; i++)
            {
                Console.WriteLine(usersMessage);
            }
        }
    }
}
