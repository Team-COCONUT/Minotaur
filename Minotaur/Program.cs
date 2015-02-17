namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using Minotaur.DrawEngines;
    using Minotaur.Interfaces;
    using Minotaur.Items;
    using Minotaur.GameSprites;
    using System.Threading;

    class Program
    {
        private static IDrawEngine drawEngine = new ConsoleDrawEngine();

        static void Main()
        {
            BattleAxe a = new BattleAxe();
          
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.SetWindowSize(120, 50);
            Console.SetBufferSize(120, 50);
            var maze = new Labyrinth(26, 10);
            drawEngine.DisplayLabyrinth(maze);

            Player player = new Player(new Coords(1, 1), 99, 3, new List<Item>(), 3, 3);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                drawEngine.DisplayText(i, 37, "=", ConsoleColor.Green);
                drawEngine.DisplayText(i, 31, "=", ConsoleColor.Green);
            }

            drawEngine.DisplayText(2, 32, "Lives: ", ConsoleColor.Green);
            drawEngine.DisplayText(15, 32, "Score: ", ConsoleColor.Green);
            Console.WriteLine();

            while (true)
            {
                drawEngine.DisplayPlayer(player);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    player.Move(pressedKey.Key, maze.Cells);
                }

                Thread.Sleep(50);
                //Console.Clear();
            }
        }
    }
}
