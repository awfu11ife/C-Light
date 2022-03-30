using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork18
{
    class Program
    {
        static void Main(string[] args)
        {
            string bracketString = "((())(()))";
            char firstSymbol;
            char lastSymbol;
            int leftBracketCount = 0;
            int rightBracketCount = 0;

            firstSymbol = bracketString[0];
            lastSymbol = bracketString[bracketString.Length - 1];

            foreach (char bracket in bracketString)
            {
                if (bracket == '(')
                {
                    leftBracketCount++;
                }
                else
                {
                    rightBracketCount++;
                }
            }

            if (leftBracketCount == rightBracketCount && firstSymbol == '(' && lastSymbol == ')')
            {
                Console.WriteLine($"Строка корректная, глубина равна {leftBracketCount - 1} ");
            }
            else
            {
                Console.WriteLine("Строка не корректная");
            }
        }   
    }
}
