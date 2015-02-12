using System;

namespace Minotaur
{
    class TextBox
    {
        public static void PrintStringAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        public static void PrintAtPosition(int x, int y, char symbol, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(symbol);
        }
    }
}
