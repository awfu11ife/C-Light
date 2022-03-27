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

            float rubleToDollar = 100;
            float rubleToEuro = 110;
            float dollarToEuro = 1.1f;

            string stopWord = "exit";
            string usersInput = "";

            Console.WriteLine("Добрый день, добро пожаловать в банк 'Закрытие'");
            Console.WriteLine("Сколько рублей у вас есть?");
            numberOfRubles = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько долларов у вас есть?");
            numberOfDollars = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько евро у вас есть?");
            numberOfEuros = Convert.ToInt32(Console.ReadLine());

            while (stopWord != usersInput)
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
                    "exit - выход \n");
                usersInput = Console.ReadLine();

                switch (usersInput)
                {
                    case "1":
                        Console.WriteLine("Сколько долларов вы хотите поменять? Текущий курс 1 к 100");
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

                    case "2":
                        Console.WriteLine("Сколько долларов вы хотите поменять? Текущий курс 1.1 к 1");
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfDollars)
                        {
                            numberOfDollars -= moneyToExchange;
                            numberOfEuros += moneyToExchange / dollarToEuro;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Сколько рублей вы хотите поменять? Текущий курс 100 к 1");
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfRubles)
                        {
                            numberOfRubles -= moneyToExchange;
                            numberOfDollars += moneyToExchange / rubleToDollar;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Сколько рублей вы хотите поменять? Текущий курс 110 к 1");
                        moneyToExchange = Convert.ToInt32(Console.ReadLine());

                        if (moneyToExchange <= numberOfRubles)
                        {
                            numberOfRubles -= moneyToExchange;
                            numberOfEuros += moneyToExchange / rubleToEuro;
                        }
                        else
                        {
                            Console.WriteLine("Извините, но у вас нет столько денег((");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Сколько евро вы хотите поменять? Текущий курс 1 к 1.1" );
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

                    case "6":
                        Console.WriteLine("Сколько евро вы хотите поменять? Текущий курс 1 к 110");
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
