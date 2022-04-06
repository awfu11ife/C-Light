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
            int fillPercent = 34;
            int maxValue = 10;
            int cursorPositionX = 0;
            int cursorPositionY = 0;

            Console.WriteLine("Введите положение бара по Х и У");
            cursorPositionX = Convert.ToInt32(Console.ReadLine());
            cursorPositionY = Convert.ToInt32(Console.ReadLine());
            DrawBar(fillPercent, maxValue, ConsoleColor.Red, cursorPositionX, cursorPositionY);
        }

        static void DrawBar(int fillPercent, int maxValue, ConsoleColor color, int cursorPositionX, int cursorPositionY)
        {
            const int HundredPercent = 100;
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = null;
            float maxValueToChange;
            char filledSymbol = '#';
            char emptySymbol = '_';
            int value;

            maxValueToChange = maxValue;
            value = Convert.ToInt32((maxValueToChange / HundredPercent) * fillPercent);

            for (int i = 0; i < value; i++)
            {
                bar += filledSymbol;
            }

            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
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
