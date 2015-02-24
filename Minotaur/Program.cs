namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using DrawEngines;
    using GameSprites;
    using GameSprites.Mobs;
    using Interfaces;
    using Items;
    using Minotaur.Generators;

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

            // TODO: find way to generate coords for both potions and mobs
            //var mobPositions = ValidPositionsGenerator.Generate(maze, 5);
            //for (int i = 1; i < mobs.Count; i++)
            //{
            //    mobs[i].Position = mobPositions[i - 1];
            //}

            var potions = new List<HealthPotion>
            {
                new HealthPotion(new Coords(10, 20), 20),
                new HealthPotion(new Coords(20, 23), 20),
                new HealthPotion(new Coords(5, 9), 20),
                new HealthPotion(new Coords(40, 10), 20),
                new HealthPotion(new Coords(50, 13), 20),
                new HealthPotion(new Coords(55, 20), 20),
                new HealthPotion(new Coords(50, 5), 20),
                new HealthPotion(new Coords(13, 23), 20)
            };
            var mobs = new List<Mob>
            {
                new Minotaur(new Coords(55, 28), 99, 3, 3, 3),
                new Bat(new Coords(11, 20)),
                new Gorgo(new Coords(5, 5)),
                new Skeleton(new Coords(50, 10)),
                new Hydra(new Coords(40, 20)),
                new Harpy(new Coords(15, 23))
            };
            var items = new List<Item>
            {
                new BattleAxe(),
                new BootsOfSwiftness(),
                new Shield(),
                new BattleAxe(),
                new BootsOfSwiftness(),
                new Shield()
            };
            var keyhanlder = new KeyHandler();
            IDrawEngine drawEngine = new ConsoleDrawEngine();
            var engine = new GameEngine(drawEngine, maze, player, keyhanlder, potions , mobs);
            engine.Run();
        }
    }
}
