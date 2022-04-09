using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork37
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = new string[5];
            string[] secondArray = new string[4];

            FillArray(firstArray);
            FillArray(secondArray);           

            foreach (var item in CreateCollection(firstArray, secondArray))
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }

        static void FillArray(string[] array)
        {
            int maxValue = 6;
            int minValue = 0;
            Random random = new Random();

            Console.Write("Массив - ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToString(random.Next(minValue, maxValue));
                Console.Write(array[i]);
            }

            Console.WriteLine();
        }

        static List<string> CreateCollection(string[] firstArray, string[] secondArray)
        {
            List<string> tempCollection = new List<string>();
            List<string> collection = new List<string>();

            AddToCollection(collection, secondArray);
            AddToCollection(collection, firstArray);

            foreach (var item in collection)
            {
                if (tempCollection.Contains(item) == false)
                {
                    tempCollection.Add(item);
                }
            }

            Console.Write("Коллекция - ");
            collection = tempCollection;            
            return collection;
        }

        static void AddToCollection(List<string> collection, string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                collection.Add(array[i]);
            }
        }
    }
}
