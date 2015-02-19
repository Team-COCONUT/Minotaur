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
         public void DisplayLabyrinth()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < this.labirinth.field.GetLength(0); row++)
            {
                for (int col = 0; col < this.labirinth.field.GetLength(1); col++)
                {
                    char charToDraw = '#';
                    if (this.labirinth.field[row, col] != CellsEnum.Wall)
                    {
                        charToDraw = ' ';
                        //Console.BackgroundColor = ConsoleColor.DarkGray;
                        //Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    sb.Append(charToDraw);
                    //Console.Write(charToDraw);
                    //Console.Write(labyrinth[i, c]);
                }

                sb.AppendLine();
                //Console.WriteLine();
            }

            Console.WriteLine(sb);
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
            this.labirinth.Generate();
            this.DisplayLabyrinth();
            Coords prevoiusPosition = new Coords(0, 0);
            while (true)
            {               
                this.DisplayPlayer(this.player);
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
