using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork33
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            FillDictionary(dictionary);
            Console.WriteLine("Это англо-русский словарь (Для выхода введите exit)");
            FindInDictionary(dictionary);
        }

        static void FillDictionary(Dictionary<string, string> dictionary)
        {
            dictionary.Add("Array", "Массив");
            dictionary.Add("Dictionary", "Словарь");
            dictionary.Add("List", "Лист");
            dictionary.Add("Stack", "стопка");
            dictionary.Add("Queue", "Очередь");
        }

        static void FindInDictionary(Dictionary<string, string> dictionary)
        {
            const string ExitWord = "exit";
            string userInput = null;

            while (userInput != ExitWord)
            {
                Console.WriteLine("Введите слово, которое хотите перевести");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ExitWord:
                        break;

                    default:
                        if (dictionary.ContainsKey(userInput))
                            Console.WriteLine($"{userInput} - {dictionary[userInput]}");
                        else
                            Console.WriteLine("Мы пока не знаем такого слова");
                        break;
                }
            }
        }
    }
}

