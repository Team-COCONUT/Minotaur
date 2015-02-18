namespace Minotaur.DrawEngines
{
    using System;
    using System.Text;

    using Minotaur;
    using Minotaur.Interfaces;
    using Minotaur.GameSprites;

    public class ConsoleDrawEngine : IDrawEngine
    {
        Player player;
        Labyrinth labirinth;
        KeyHandler keyhandler;

        public ConsoleDrawEngine(Player player, Labyrinth labirinth, KeyHandler keyboard)
        {
            this.player = player;
            this.labirinth = labirinth;
            this.keyhandler = keyboard;
        }
        public void DisplayLabyrinth(Labyrinth labyrinth)
        {
            var firstLine = string.Empty;

            for (var col = 0; col < labyrinth.Height; col++)
            {
                var sbTop = new StringBuilder();
                var sbMid = new StringBuilder();

                for (var row = 0; row < labyrinth.Width; row++)
                {
                    sbTop.Append(labyrinth[row, col].HasFlag(CellState.Top) ? "+--" : "+  ");
                    sbMid.Append(labyrinth[row, col].HasFlag(CellState.Left) ? "|  " : "   ");
                }

                if (firstLine == string.Empty)
                {
                    firstLine = sbTop.ToString();
                }

                Console.WriteLine(sbTop + "+");
                Console.WriteLine(sbMid + "|");
                Console.WriteLine(sbMid + "|");
            }

            Console.WriteLine(firstLine + "+");
        }

        public void MovePlayer(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                    this.player.MoveUp();
                    break;
                case Directions.Down:
                    this.player.MoveDown();
                    break;
                case Directions.Right:
                    this.player.MoveRight();
                    break;
                case Directions.Left:
                    this.player.MoveLeft();
                    break;
                default:
                    break;
            }
        }

        public void DisplayText(int x, int y, string text, ConsoleColor color)
        {
            this.PrintStringAtPosition(x, y, text, color);
        }

        public void DisplayPlayer(Player player)
        {
            this.PrintStringAtPosition(player.Position.X, player.Position.Y, "#", ConsoleColor.Blue);
        }

        private void PrintStringAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        public void Run()
        {
            this.DisplayLabyrinth(labirinth);
            Coords prevoiusPosition = new Coords(0, 0);
            while (true)
            {               
                this.DisplayPlayer(this.player);
                System.Threading.Thread.Sleep(200);
                prevoiusPosition.X = this.player.Position.X;
                prevoiusPosition.Y = this.player.Position.Y;
                this.keyhandler.CheckKey();
                Console.SetCursorPosition(prevoiusPosition.X, prevoiusPosition.Y);
                Console.Write(" ");
            }
        }
    }
}
