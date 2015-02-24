namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using DrawEngines;
    using GameSprites;
    using GameSprites.Mobs;
    using Interfaces;
    using Items;

    public class Program
    {
        public static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 49;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.SetWindowSize(120, 49);
            Console.SetBufferSize(120, 49);
            var maze = new Labyrinth(30, 80);

            var player = new Player(new Coords(1, 1), 99, 3, new List<Item>(), 3, 3);
            var minotaur = new Minotaur(new Coords(55, 28), 99, 3, 3, 3);
            var keyhanlder = new KeyHandler();
            IDrawEngine drawEngine = new ConsoleDrawEngine();
            var engine = new GameEngine(drawEngine, maze, player, keyhanlder, minotaur);
            engine.Run();
        }
    }
}
