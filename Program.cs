using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            float numberOfDollars;
            float numberOfEuros;
            float numberOfRubles;
            float moneyToExchange;

            float rubleToDollar = 100f;
            float dollarToRuble = 0.01f;
            float rubleToEuro = 110f;
            float euroToRuble = 0.009f;
            float dollarToEuro = 1.1f;
            float euroToDollar = 0.9f;

            int stopNumber = 0;
            int ?usersInput = null;

            Console.WriteLine("Добрый день, добро пожаловать в банк 'Закрытие'");
            Console.WriteLine("Сколько рублей у вас есть?");
            numberOfRubles = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько долларов у вас есть?");
            numberOfDollars = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько евро у вас есть?");
            numberOfEuros = Convert.ToInt32(Console.ReadLine());

            while (stopNumber != usersInput)
            {
                Console.WriteLine($"\nУ вас на счету - {numberOfDollars} долларов, {numberOfEuros} евро и {numberOfRubles} рублей");
                Console.WriteLine("Какую валюту вы хотели бы обменять?");
                Console.WriteLine(
                    "1-Доллары на рубли \n" +
                    "2-Доллары на евро \n" +
                    "3-Рубли на доллары \n" +
                    "4-Рубли на евро \n" +
                    "5-Евро на доллары \n" +
                    "6-Евро на рубли \n" +
                    "0-выход \n");
                usersInput = Convert.ToInt32(Console.ReadLine());

                switch (usersInput)
                {
                    case 1:
                        Console.WriteLine($"Сколько долларов вы хотите поменять? За доллар вы можетекупить {rubleToDollar} рублей ");
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfDollars)
                        {
                            numberOfDollars -= moneyToExchange;
                            numberOfRubles += moneyToExchange * rubleToDollar;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                    case 2:
                        Console.WriteLine($"Сколько долларов вы хотите поменять? За один доллар вы получите {euroToDollar} евро");
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfDollars)
                        {
                            numberOfDollars -= moneyToExchange;
                            numberOfEuros += moneyToExchange * euroToDollar;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Сколько рублей вы хотите поменять? ЗА один рубль вы получите {dollarToRuble} долларов");
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfRubles)
                        {
                            numberOfRubles -= moneyToExchange;
                            numberOfDollars += moneyToExchange * dollarToRuble;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                    case 4:
                        Console.WriteLine($"Сколько рублей вы хотите поменять? За один рубль вы получите {euroToRuble} евро");
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfRubles)
                        {
                            numberOfRubles -= moneyToExchange;
                            numberOfEuros += moneyToExchange * euroToRuble;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                    case 5:
                        Console.WriteLine($"Сколько евро вы хотите поменять? За один евро вы получите {dollarToEuro} долларов" );
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfRubles)
                        {
                            numberOfEuros -= moneyToExchange;
                            numberOfDollars += moneyToExchange * dollarToEuro;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                    case 6:
                        Console.WriteLine($"Сколько евро вы хотите поменять? За один евро вы получите {rubleToEuro} рублей");
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfRubles)
                        {
                            numberOfEuros -= moneyToExchange;
                            numberOfRubles += moneyToExchange * rubleToEuro;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                }
            }
        }
    }
}
