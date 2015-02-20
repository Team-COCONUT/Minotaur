using Minotaur.GameSprites;
using Minotaur.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaur
{
    public class GameEngine
    {

        private IDrawEngine drawEngine;
        private Labyrinth labyrinth;
        private Player player; 
        private KeyHandler keyhandler;

        public GameEngine(IDrawEngine drawEngine, Labyrinth labyrinth, Player player,KeyHandler handler)
        {
            this.DrawEngine = drawEngine;
            this.Labyrinth = labyrinth;
            this.Player = player;
            this.KeyHandler = handler;
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

        public void Run()
        {
            this.Labyrinth.Generate();
            this.DrawEngine.DisplayLabyrinth(this.Labyrinth);
            Coords prevoiusPosition = new Coords(0, 0);
            keyhandler.ImplementMove(this.Player, this.Labyrinth);
            while (true)
            {
                this.DrawEngine.DisplayPlayer(this.Player);
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
