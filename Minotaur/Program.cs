﻿namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using DrawEngines;
    using GameSprites;
    using GameSprites.Mobs;
    using GameSprites.Potions;
    using Interfaces;
    using Items;
    using Generators;

    public class Program
    {
        public static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 49;
            Console.BufferWidth = Console.WindowWidth = 81;
            Console.SetWindowSize(80, 49);
            Console.SetBufferSize(80, 49);

            Labyrinth maze = new Labyrinth(30, 80);
            maze.Generate();

            Player player = new Player(new Coords(1, 1), 99, 50, new List<Item>(), 30, 3);

            ValidPositionsGenerator positionGenerator = ValidPositionsGenerator.GetInstance;
            IList<Coords> availablePositions = positionGenerator.Generate(maze, 30);

            List<Potion> potions = new List<Potion>
            {
                new HealthPotion(),
                new DefensePotion(),
                new AttackPotion(),
                new HealthPotion(),
                new DefensePotion(),
                new AttackPotion(),
                new HealthPotion(),
                new DefensePotion(),
                new AttackPotion(),
                new HealthPotion()
            };
            for (int potionCounter = 0; potionCounter < potions.Count; potionCounter++)
            {
                potions[potionCounter].Position = availablePositions[potionCounter];
                availablePositions.RemoveAt(potionCounter);
            }

            List<Mob> mobs = new List<Mob>
            {
                new Minotaur(position: new Coords(79, 29), healthPoints: 99, attackPoints: 3, defensePoints: 3, minotaurSpeed: 3),
                new Bat(),
                new Gorgo(),
                new Skeleton(),
                new Hydra(),
                new Harpy(),
                new Bat(),
                new Gorgo(),
                new Skeleton(),
                new Hydra()
            };
            for (int mobCounter = 1; mobCounter < mobs.Count; mobCounter++)
            {
                mobs[mobCounter].Position = availablePositions[mobCounter];
                availablePositions.RemoveAt(mobCounter);
            }

            List<Item> items = new List<Item>
            {
                new BattleAxe(),
                new BootsOfSwiftness(),
                new Shield(),
                new BattleAxe(),
                new BootsOfSwiftness(),
                new Shield()
            };
            for (int itemCounter = 0; itemCounter < items.Count; itemCounter++)
            {
                items[itemCounter].Position = availablePositions[itemCounter];
                availablePositions.RemoveAt(itemCounter);
            }

            KeyHandler keyhanlder = new KeyHandler();
            IDrawEngine drawEngine = new ConsoleDrawEngine();
            GameEngine engine = new GameEngine(drawEngine, maze, player, keyhanlder, potions, mobs, items);
            engine.Run();
        }
    }
}
