namespace Minotaur
{
    using System;

    using Enumerations;
    using GameSprites;

    public class KeyHandler
    {
        public event EventHandler OnLeftArrowPressed;
        public event EventHandler OnRightArrowPressed;
        public event EventHandler OnUpArrowPressed;
        public event EventHandler OnDownArrowPressed;

        public void CheckKey()
        {
            if (Console.KeyAvailable)
            {
                var pressedkey = Console.ReadKey();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedkey.Key.Equals(ConsoleKey.LeftArrow))
                {
                    this.OnLeftArrowPressed(this, new EventArgs());
                }

                if (pressedkey.Key.Equals(ConsoleKey.RightArrow))
                {
                    this.OnRightArrowPressed(this, new EventArgs());
                }

                if (pressedkey.Key.Equals(ConsoleKey.UpArrow))
                {
                    this.OnUpArrowPressed(this, new EventArgs());
                }

                if (pressedkey.Key.Equals(ConsoleKey.DownArrow))
                {
                    this.OnDownArrowPressed(this, new EventArgs());
                }
            }
        }

        public void ImplementMove(Player player, Labyrinth labyrinth)
        {
            this.OnRightArrowPressed += (sender, eventInfo) => player.Move(Directions.Right, labyrinth);
            this.OnLeftArrowPressed += (sender, eventInfo) => player.Move(Directions.Left, labyrinth);
            this.OnUpArrowPressed += (sender, eventInfo) => player.Move(Directions.Up, labyrinth);
            this.OnDownArrowPressed += (sender, eventInfo) => player.Move(Directions.Down, labyrinth);
        }
    }
}
