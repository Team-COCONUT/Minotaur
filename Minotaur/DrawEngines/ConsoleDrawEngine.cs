namespace Minotaur.DrawEngines
{
    using System;
    using System.Text;

    using Minotaur;
    using Minotaur.Interfaces;

    public class ConsoleDrawEngine : IDrawEngine
    {
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

        public void DisplayText(int x, int y, string text, ConsoleColor color)
        {
            this.PrintStringAtPosition(x, y, text, color);
        }

        private void PrintStringAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
