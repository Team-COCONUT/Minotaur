namespace Minotaur
{
    using Minotaur.DrawEngines;
    using Minotaur.Interfaces;
    using System;

    public  class KeyHandler
    {
        public event EventHandler OnLeftArrowPressed;

        public event EventHandler OnRightArrowPressed;

        public event EventHandler OnUpArrowPressed;

        public event EventHandler OnDownArrowPressed;

        public void CheckKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedkey = Console.ReadKey();
                if (pressedkey.Key.Equals(ConsoleKey.LeftArrow))
                {
                    this.OnLeftArrowPressed(this, new EventArgs());
                }

                if (pressedkey.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightArrowPressed != null)
                    {
                        this.OnRightArrowPressed(this, new EventArgs());
                    }
                }

                if (pressedkey.Key.Equals(ConsoleKey.UpArrow))
                {
                    this.OnUpArrowPressed(this, new EventArgs());
                }

                if (pressedkey.Key.Equals(ConsoleKey.DownArrow))
                {
                    this.OnDownArrowPressed(this, new EventArgs());
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }
        public void ImplementMove(ConsoleDrawEngine engine)
        {
            this.OnRightArrowPressed += (sender, eventInfo) =>
            {
                engine.MovePlayer(Directions.Right);
            };
            this.OnLeftArrowPressed+=(sender,eventInfo)=>
            {
                engine.MovePlayer(Directions.Left);
            };
            this.OnUpArrowPressed+=(sender,eventInfo)=>
            {
                engine.MovePlayer(Directions.Up);
            };
            this.OnDownArrowPressed += (sender, eventInfo) =>
            {
                engine.MovePlayer(Directions.Down);
            };
        }
    }
}
