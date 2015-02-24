using Minotaur.Items;

namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using DrawEngines;
    using GameSprites;
    using Interfaces;

    public class Program
    {
        public static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 49;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.SetWindowSize(120, 49);
            Console.SetBufferSize(120, 49);
            var maze = new Labyrinth(30, 80);

            Player player = new Player(new Coords(1, 1), 99, 3, new List<Item>(), 3, 3);
            KeyHandler keyhanlder = new KeyHandler();
            IDrawEngine drawEngine = new ConsoleDrawEngine();
            GameEngine engine = new GameEngine(drawEngine, maze, player, keyhanlder);
            engine.Run();
        }
    }
}
