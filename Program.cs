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
            MergeArray(firstArray, secondArray);
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

        static void MergeArray(string[] firstArray, string[] secondArray)
        {
            string[] finalArray = new string[firstArray.Length + secondArray.Length];
            List<string> tempArray = new List<string>();

            firstArray.CopyTo(finalArray, 0);
            secondArray.CopyTo(finalArray, firstArray.Length);

            foreach (var item in finalArray)
            {
                if (tempArray.Contains(item) == false)
                {
                    tempArray.Add(item);
                }
            }

            finalArray = tempArray.ToArray();
            Console.Write("Конечный массив - ");

            foreach (var item in finalArray)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }
    }
}
