namespace Minotaur.DrawEngines
{
    using System;
    using System.Text;

    using Enumerations;
    using GameSprites;
    using GameSprites.Mobs;
    using Interfaces;
    using Items;

    public class ConsoleDrawEngine : IDrawEngine
    {
        public void DisplayLabyrinth(Labyrinth labyrinth)
        {
            var sb = new StringBuilder();

            for (var row = 0; row < labyrinth.Field.GetLength(0); row++)
            {
                for (var col = 0; col < labyrinth.Field.GetLength(1); col++)
                {
                    var charToDraw = '#';
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

        public void DisplayMinotaur(Minotaur minotaur)
        {
            this.PrintStringAtPosition(minotaur.Position.X, minotaur.Position.Y, "V", ConsoleColor.Red);
        }

        public void DisplayHealthPotion(HealthPotion potion)
        {
            this.PrintStringAtPosition(potion.Position.X, potion.Position.Y, "o", ConsoleColor.Red);
        }

        private void PrintStringAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
