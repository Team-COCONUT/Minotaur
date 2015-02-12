using System;

namespace Minotaur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.SetWindowSize(120, 50);
            Console.SetBufferSize(120, 50);
            var maze = new Labyrinth(26, 10);
            maze.Display();

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                TextBox.PrintAtPosition(i, 37, '=', ConsoleColor.Green);
                TextBox.PrintAtPosition(i, 31, '=', ConsoleColor.Green);
            }
            TextBox.PrintStringAtPosition(2, 32, "Lives: ", ConsoleColor.Green);
            TextBox.PrintStringAtPosition(15, 32, "Score: ", ConsoleColor.Green);
            Console.WriteLine();
        }
    }
}
