namespace Minotaur
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;

    using Artifacts.Items;
    using Artifacts.Potions;
    using GameSprites;
    using GameSprites.Mobs;
    using Interfaces;
    using DrawEngines;
    using Exceptions;
    using Generators;

    public class GameEngine
    {
        private IDrawEngine drawEngine;
        private Labyrinth labyrinth;
        private Player player;
        private KeyHandler keyhandler;
        private IList<Potion> potions;
        private IList<GameSprite> mobs;
        private IList<Item> items;

        private static Random randomNumberGenerator = new Random();

        public GameEngine()
        {
            IDrawEngine drawEngine = new ConsoleDrawEngine();
            Labyrinth maze = new Labyrinth(30, 80);
            maze.Generate();

            KeyHandler keyhanlder = new KeyHandler();
            ValidPositionsGenerator positionGenerator = ValidPositionsGenerator.GetInstance;
            IList<Coords> availablePositions = positionGenerator.Generate(maze, 30);

            Player player = new Player(position: new Coords(1, 1), healthPoints: 50, attackPoints: 10, defensePoints: 12, inventory: new List<Item>());
            IList<Potion> potions = this.GeneratePotions(10, availablePositions);
            IList<GameSprite> mobs = this.GenerateMobs(9, availablePositions);
            IList<Item> items = this.GenerateItems(6, availablePositions);

            this.DrawEngine = drawEngine;
            this.Labyrinth = maze;
            this.KeyHandler = keyhanlder;
            this.Player = player;
            this.Potions = potions;
            this.Mobs = mobs;
            this.Items = items;
        }

        private Labyrinth Labyrinth
        {
            get
            {
                return this.labyrinth;
            }

            set
            {
                this.labyrinth = value;
            }
        }

        private Player Player
        {
            get
            {
                return this.player;
            }

            set
            {
                this.player = value;
            }
        }

        private IDrawEngine DrawEngine
        {
            get
            {
                return this.drawEngine;
            }

            set
            {
                this.drawEngine = value;
            }
        }

        private KeyHandler KeyHandler
        {
            get
            {
                return this.keyhandler;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must provide a KeyHanlder implementation.");
                }

                this.keyhandler = value;
            }
        }

        private IList<Potion> Potions
        {
            get { return this.potions; }
            set { this.potions = value; }
        }

        private IList<GameSprite> Mobs
        {
            get { return this.mobs; }
            set { this.mobs = value; }
        }

        private IList<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public static bool RedrawLabyrinth { get; set; }

        public void Run()
        {
            Coords prevoiusPosition = new Coords(0, 0);
            keyhandler.ImplementMove(this.Player, this.Labyrinth);

            this.DrawEngine.DisplayLabyrinth(this.Labyrinth, prevoiusPosition.X, prevoiusPosition.Y);

            try
            {
                while (true)
                {
                    if (!this.Player.IsAlive())
                    {
                        throw new PlayerIsDeadException();
                    }
                    
                    if (!this.IsMinotourAlive())
                    {
                        throw new MinotourIsDeadException();
                    }

                    if (RedrawLabyrinth)
                    {
                        this.DrawEngine.DisplayLabyrinth(this.Labyrinth, prevoiusPosition.X, prevoiusPosition.Y);
                        RedrawLabyrinth = false;
                    }

                    CollisionChecker.CheckPotionCollision(this.Player, this.Potions);
                    CollisionChecker.CheckMobCollision(this.Player, this.Mobs);
                    CollisionChecker.CheckItemCollision(this.Player, this.Items);
                    this.DrawEngine.DisplayPlayer(this.Player);

                    prevoiusPosition.X = this.player.Position.X;
                    prevoiusPosition.Y = this.player.Position.Y;
                    this.DrawEngine.DisplayPotion(this.Potions, prevoiusPosition.X, prevoiusPosition.Y);
                    this.DrawEngine.DisplayMobs(this.Mobs, prevoiusPosition.X, prevoiusPosition.Y);
                    this.DrawEngine.DisplayItems(this.Items, prevoiusPosition.X, prevoiusPosition.Y);

                    Thread.Sleep(200);

                    this.DrawEngine.ClearPosition(prevoiusPosition.X, prevoiusPosition.Y);
                    this.keyhandler.CheckKey();

                    Console.SetCursorPosition(0, 30);
                    Console.WriteLine(player.ToString());
                }
            }
            catch (GameOverException ex)
            {
                this.DrawEngine.ClearAll();
                ConsoleDrawEngine.DisplayStickyMsg(ex.Message, "The game will be restarted...");
                LabyrinthMain.Main();
            }
        }

        private bool IsMinotourAlive()
        {
            return this.Mobs.FirstOrDefault(m => m.GetType().Name == "Minotaur") != null;
        }

        private IList<Potion> GeneratePotions(int potionsCount, IList<Coords> availablePositions)
        {
            List<Potion> potions = new List<Potion>();

            for (int i = 0; i < potionsCount; i++)
            {
                potions.Add(this.RandomPotion());
                potions[i].Position = availablePositions[i];
                availablePositions.RemoveAt(i);
            }

            return potions;
        }

        private IList<Item> GenerateItems(int itemsCount, IList<Coords> availablePositions)
        {
            List<Item> items = new List<Item>();

            for (int i = 0; i < itemsCount; i++)
            {
                items.Add(this.RandomItem());
                items[i].Position = availablePositions[i];
                availablePositions.RemoveAt(i);
            }

            return items;
        }

        private IList<GameSprite> GenerateMobs(int mobsCount, IList<Coords> availablePositions)
        {
            List<GameSprite> mobs = new List<GameSprite>();

            for (int i = 0; i < mobsCount; i++)
            {
                mobs.Add(this.RandomMob());
                mobs[i].Position = availablePositions[i];
                availablePositions.RemoveAt(i);
            }
            mobs.Add(new Minotaur(position: new Coords(79, 29), healthPoints: 99, attackPoints: 20, defensePoints: 20));

            return mobs;
        }

        private Potion RandomPotion()
        {
            int potionCase = randomNumberGenerator.Next(0, 3);

            switch (potionCase)
            {
                case 0:
                    return new HealthPotion();
                case 1:
                    return new DefensePotion();
                default:
                    return new AttackPotion();
            }
        }

        private Item RandomItem()
        {
            int itemCase = randomNumberGenerator.Next(0, 5);

            switch (itemCase)
            {
                case 0:
                    return new BattleAxe();
                case 1:
                    return new BootsOfSwiftness();
                case 2:
                    return new Shield();
                case 3:
                    return new BattleAxe();
                case 4:
                    return new BootsOfSwiftness();
                default:
                    return new Shield();
            }
        }

        private GameSprite RandomMob()
        {
            int mobCase = randomNumberGenerator.Next(0, 5);

            switch (mobCase)
            {
                case 0:
                    return new Bat();
                case 1:
                    return new Gorgo();
                case 2:
                    return new Skeleton();
                case 3:
                    return new Hydra();
                default:
                    return new Harpy();
            }
        }
    }
}
