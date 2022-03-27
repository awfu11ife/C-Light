using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 5;
            int lastNumber = 96;
            int step = 7;

            for (int i = firstNumber; i <= lastNumber; i+=step)
            {
                Console.WriteLine(i);
            }
        }
    }
}
