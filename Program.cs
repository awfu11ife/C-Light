using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork26
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "Практика с методом String.Split()";
            string[] splitedSentence = sentence.Split();

            foreach (var word in splitedSentence)
            {
                Console.WriteLine(word);
            }
        }
    }
}
