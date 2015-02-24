namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using GameSprites;
    using GameSprites.Mobs;
    using Interfaces;
    using Items;

    public class GameEngine
    {
        private IDrawEngine drawEngine;
        private Labyrinth labyrinth;
        private Player player; 
        private KeyHandler keyhandler;
        private List<HealthPotion> potions;
        private List<Mob> mobs; 

        public GameEngine(IDrawEngine drawEngine, 
            Labyrinth labyrinth, 
            Player player, 
            KeyHandler handler,
            List<HealthPotion> potions, 
            List<Mob> mobs)
        {
            this.DrawEngine = drawEngine;
            this.Labyrinth = labyrinth;
            this.Player = player;
            this.KeyHandler = handler;
            this.Potions = potions;
            this.Mobs = mobs;
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

        public List<HealthPotion> Potions
        {
            get { return potions; }
            set { potions = value; }
        }

        public List<Mob> Mobs
        {
            get { return mobs; }
            set { mobs = value; }
        }

        public void Run()
        {
            this.Labyrinth.Generate();
            this.DrawEngine.DisplayLabyrinth(this.Labyrinth);
            var prevoiusPosition = new Coords(0, 0);
            keyhandler.ImplementMove(this.Player, this.Labyrinth);

            while (true)
            {
                CollisionChecker.Check(this.Player, this.Potions, this.Mobs);
                this.DrawEngine.DisplayPlayer(this.Player);
                this.DrawEngine.DisplayHealthPotion(this.Potions);
                this.DrawEngine.DisplayMobs(this.Mobs);
                System.Threading.Thread.Sleep(200);
                prevoiusPosition.X = this.player.Position.X;
                prevoiusPosition.Y = this.player.Position.Y;
                Console.SetCursorPosition(prevoiusPosition.X, prevoiusPosition.Y);
                Console.Write("");
                this.keyhandler.CheckKey();
            }
        }
    }
}
