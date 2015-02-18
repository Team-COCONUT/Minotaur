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
        static void Main()
        {            
            Console.BufferHeight = Console.WindowHeight = 49;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.SetWindowSize(120, 49);
            Console.SetBufferSize(120, 49);
            var maze = new Labyrinth(26, 10);
            //drawEngine.DisplayLabyrinth(maze);

            Player player = new Player(new Coords(1, 1), 99, 3, new List<Item>(), 3, 3);
            KeyHandler keyboard = new KeyHandler();
             ConsoleDrawEngine drawEngine = new ConsoleDrawEngine(player,maze,keyboard);
            keyboard.ImplementMove(drawEngine);
            drawEngine.Run();
            //for (int i = 0; i < Console.WindowWidth; i++)
            //{
            //    drawEngine.DisplayText(i, 37, "=", ConsoleColor.Green);
            //    drawEngine.DisplayText(i, 31, "=", ConsoleColor.Green);
            //}

            //drawEngine.DisplayText(2, 32, "Lives: ", ConsoleColor.Green);
            //drawEngine.DisplayText(15, 32, "Score: ", ConsoleColor.Green);
            //Console.WriteLine();


            //while (true)
            //{
            //    drawEngine.DisplayPlayer(player);

            //    if (Console.KeyAvailable)
            //    {
            //        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            //        while (Console.KeyAvailable)
            //        {
            //            Console.ReadKey(true);
            //        }
            //        player.Move(pressedKey.Key, maze.Cells);
            //    }

            //    Thread.Sleep(50);
            //    //Console.Clear();
            //}
        }
    }
}
