namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using GameSprites;
    using GameSprites.Mobs;
    using GameSprites.Potions;
    using Interfaces;
    using Items;

    public class GameEngine
    {
        private IDrawEngine drawEngine;
        private Labyrinth labyrinth;
        private Player player; 
        private KeyHandler keyhandler;
        private List<Potion> potions;
        private List<Mob> mobs;
        private List<Item> items; 

        public GameEngine(IDrawEngine drawEngine, 
            Labyrinth labyrinth, 
            Player player, 
            KeyHandler handler,
            List<Potion> potions, 
            List<Mob> mobs, 
            List<Item> items)
        {
            this.DrawEngine = drawEngine;
            this.Labyrinth = labyrinth;
            this.Player = player;
            this.KeyHandler = handler;
            this.Potions = potions;
            this.Mobs = mobs;
            this.Items = items;
        }

        public Labyrinth Labyrinth
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

        public Player Player
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

        public IDrawEngine DrawEngine
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

        public KeyHandler KeyHandler 
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

        public List<Potion> Potions
        {
            get { return potions; }
            set { potions = value; }
        }

        public List<Mob> Mobs
        {
            get { return mobs; }
            set { mobs = value; }
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        public void Run()
        { 
            var prevoiusPosition = new Coords(0, 0);
            keyhandler.ImplementMove(this.Player, this.Labyrinth);

            this.DrawEngine.DisplayLabyrinth(this.Labyrinth, prevoiusPosition.X, prevoiusPosition.Y);

            while (true)
            {
                CollisionChecker.Check(this.Player, this.Potions, this.Mobs, this.Items);
                this.DrawEngine.DisplayPlayer(this.Player);

                prevoiusPosition.X = this.player.Position.X;
                prevoiusPosition.Y = this.player.Position.Y;
                this.DrawEngine.DisplayPotion(this.Potions, prevoiusPosition.X, prevoiusPosition.Y);
                this.DrawEngine.DisplayMobs(this.Mobs, prevoiusPosition.X, prevoiusPosition.Y);
                this.DrawEngine.DisplayItems(this.Items, prevoiusPosition.X, prevoiusPosition.Y);

                System.Threading.Thread.Sleep(200);

                Console.SetCursorPosition(prevoiusPosition.X, prevoiusPosition.Y);
                Console.Write("");
                this.keyhandler.CheckKey();

                Console.SetCursorPosition(0, 30);
                Console.WriteLine(player.ToString());
                //TODO : implement print inventory
            }
        }
    }
}
