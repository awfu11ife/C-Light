using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "oralcumshot";
            string secretMessage = "AHHHHHHH YOU ARE BOSS OF THIS GYM";
            string userInput = null;
            int tryCount = 3;

            Console.WriteLine("Тут зашифровано сообщение, для просмотра введите пароль");
            while (tryCount > 0 ^ userInput == password)
            {
                userInput = Console.ReadLine();
                
                if (userInput == password)
                {
                    Console.WriteLine("Доступ разблокирован, ");
                    Console.WriteLine(secretMessage);
                }
                else
                {   
                    tryCount--;
                    if (tryCount == 0)
                    {
                        Console.WriteLine("Попытки кончились, попробуйте в другой раз");
                    }
                    else
                    {
                        Console.WriteLine("Пароль неверный, попробуйте ещё раз");
                    }
                }
            }
        }
    }
}
