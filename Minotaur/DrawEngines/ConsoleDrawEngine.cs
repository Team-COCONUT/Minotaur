namespace Minotaur.DrawEngines
{
    using System;
    using System.Collections.Generic;
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
            this.PrintStringAtPosition(player.Position.X, player.Position.Y, player.DisplayChar.ToString(), ConsoleColor.Blue);
        }

        public void DisplayMinotaur(Minotaur minotaur)
        {
            this.PrintStringAtPosition(minotaur.Position.X, minotaur.Position.Y, "V", ConsoleColor.Red);
        }

        public void DisplayHealthPotion(List<HealthPotion> potions)
        {
            foreach (var potion in potions)
            {
                this.PrintStringAtPosition(potion.Position.X, potion.Position.Y, "o", ConsoleColor.Green);
            }
        }

        public void DisplayMobs(List<Mob> mobs)
        {
            foreach (var mob in mobs)
            {
                this.PrintStringAtPosition(mob.Position.X, mob.Position.Y, mob.DisplayChar.ToString(), ConsoleColor.Yellow);     
            }
        }

        public void DisplayItems(List<Item> items)
        {
            foreach (var item in items)
            {
                this.PrintStringAtPosition(item.Position.X, item.Position.Y, item.DisplayChar.ToString(), ConsoleColor.Magenta);
            }
        }

        private void PrintStringAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
