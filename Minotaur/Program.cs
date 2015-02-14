namespace Minotaur
{
    using System;

    using Minotaur.DrawEngines;
    using Minotaur.Interfaces;

    class Program
    {
        private static IDrawEngine drawEngine = new ConsoleDrawEngine();

        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.SetWindowSize(120, 50);
            Console.SetBufferSize(120, 50);
            var maze = new Labyrinth(26, 10);
            drawEngine.DisplayLabyrinth(maze);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                drawEngine.DisplayText(i, 37, "=", ConsoleColor.Green);
                drawEngine.DisplayText(i, 31, "=", ConsoleColor.Green);
            }

            drawEngine.DisplayText(2, 32, "Lives: ", ConsoleColor.Green);
            drawEngine.DisplayText(15, 32, "Score: ", ConsoleColor.Green);
            Console.WriteLine();
        }
    }
}
