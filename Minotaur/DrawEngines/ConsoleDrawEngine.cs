namespace Minotaur.DrawEngines
{
    using System;
    using System.Text;

    using Minotaur;
    using Minotaur.Interfaces;
    using Minotaur.GameSprites;

    public class ConsoleDrawEngine : IDrawEngine
    {
        public ConsoleDrawEngine()
        {
        }

        public void DisplayLabyrinth(Labyrinth labyrinth)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < labyrinth.Field.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.Field.GetLength(1); col++)
                {
                    char charToDraw = '#';
                    if (labyrinth.Field[row, col] != CellsEnum.Wall)
                    {
                        charToDraw = ' ';
                    }

                    sb.Append(charToDraw);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb);
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
    }
}
