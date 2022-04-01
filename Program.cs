using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string bracketString = "(())";
            string changeBracketStrig;
            int leftBracketCount = 0;
            int rightBracketCount = 0;
            int baseMaxDepth = 1;
            int currentMaxDepth = 0;
            bool isCorrect = true;

            changeBracketStrig = bracketString;

            if (bracketString == "")
            {
                isCorrect = false;
            }

            foreach (char bracket in changeBracketStrig)
            {
                if (bracket == '(')
                {
                    leftBracketCount++;
                }
                else if (bracket == ')')
                {
                    rightBracketCount++;
                }
            }

            if (leftBracketCount == rightBracketCount)
            {
                for (int i = 0; i < changeBracketStrig.Length; i++)
                {
                    if (changeBracketStrig[i] == ')')
                    {
                        isCorrect = false;
                        break;
                    }
                    else
                    {
                        changeBracketStrig = changeBracketStrig.Remove(i, 1);
                        i = -1;

                        for (int j = 0; j < changeBracketStrig.Length; j++)
                        {
                            if (changeBracketStrig[j] == ')')
                            {
                                changeBracketStrig = changeBracketStrig.Remove(j, 1);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                isCorrect = false;
            }

            if (isCorrect == true)
            {
                Console.WriteLine("Корректное скобочное выражение");
                for (int i = 0; i < bracketString.Length - 1; i++)
                {
                    if (bracketString[i] == '(')
                    {
                        currentMaxDepth++;
                    }
                    else
                    {
                        if (baseMaxDepth <= currentMaxDepth)
                        {
                            baseMaxDepth = currentMaxDepth;
                            currentMaxDepth = 0;
                        }                        
                    }
                }
                Console.WriteLine("Глубина равна " + baseMaxDepth);               
            }

            else
            {
                Console.WriteLine("Некорректное скобочное выражение");
            }

        }
    }
}
