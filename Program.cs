using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    class Program
    {
        static void Main(string[] args)
        {
            string usersInput = null;
            string usersName = null;
            string usersPassword = null;

            const string stopWord = "exit";
            const string setNameCommand = "setname";
            const string setPasswordCommand = "setpassword";
            const string writeNameCommand = "writename";
            const string consoleClearCommand = "consoleclear";
            const string changeTextColorCommand = "changetextcolor";

            Console.WriteLine("Добро пожаловать\n");

            while (usersInput != stopWord)
            {
                Console.WriteLine("Вам доступен следующий список команд:\n" +
                    "SetName - установить имя\n" +
                    "SetPassword - установить пароль\n" +
                    "WriteName - вывести имя\n" +
                    "ConsoleClear - очистить консоль\n" +
                    "ChangeTextColor изменить цвет текста на зеленый\n" +
                    "Exit - завершить программу\n");
                Console.WriteLine("Введите желаемую команду (регистр не влияет)");
                usersInput = Console.ReadLine().ToLower();

                switch (usersInput)
                {
                    case setNameCommand:
                        Console.WriteLine("\nВведите ваше имя\n");
                        usersName = Console.ReadLine();
                        Console.WriteLine($"\nДобрый день {usersName}, приятно познакомиться!\n");
                        break;

                    case setPasswordCommand:
                        Console.WriteLine("\nУстановите пароль\n");
                        usersPassword = Console.ReadLine();
                        Console.WriteLine("\nЯ обещаю, что никому его не скажу\n");
                        break;

                    case writeNameCommand:
                        if(usersName != null && usersPassword != null)
                        {
                            Console.WriteLine("\nДля вывода имени введите пароль:\n");
                            usersInput = Console.ReadLine();
                            if (usersInput == usersPassword)
                            {
                                Console.WriteLine($"\nВас зовут {usersName}\n");
                            }
                            else
                            {
                                Console.WriteLine("\nПароль введён не верно\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nДля начала установите имя и пароль\n");
                        }
                        break;

                    case consoleClearCommand:
                        Console.Clear();
                        break;

                    case changeTextColorCommand:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    default:
                        Console.WriteLine("\nИзвините, я не знаю такой команды. Попробуйте снова\n");
                        break;
                }
            }
        }
    }
}
