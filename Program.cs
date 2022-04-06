using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork29
{
    class Program
    {
        static void Main(string[] args)
        {
            float fillPercent = 34;
            int maxValue = 10;
            int cursorPosX = 0;
            int cursorPosY = 0;

            Console.WriteLine("Введите положение бара по Х и У");
            cursorPosX = Convert.ToInt32(Console.ReadLine());
            cursorPosY = Convert.ToInt32(Console.ReadLine());
            DrawBar(fillPercent, maxValue, ConsoleColor.Red, cursorPosX, cursorPosY);
        }

        static void DrawBar(float fillPercent, int maxValue, ConsoleColor color, int cursorPosX, int cursorPosY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = null;
            float maxValueToChange;
            char filledSymbol = '#';
            char emptySymbol = '_';
            int value;

            maxValueToChange = maxValue;
            value = Convert.ToInt32((maxValueToChange / 100) * fillPercent);

            for (int i = 0; i < value; i++)
            {
                bar += filledSymbol;
            }

            Console.SetCursorPosition(cursorPosX, cursorPosY);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;
            bar = null;

            for (int i = value; i < maxValue; i++)
            {
                bar += emptySymbol;
            }

            Console.Write(bar + "]");
        }
    }
}
