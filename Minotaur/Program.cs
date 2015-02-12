using System;

namespace Minotaur
{
    class Program
    {
        static void Main(string[] args)
        {
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
