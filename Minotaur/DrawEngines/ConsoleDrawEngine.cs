namespace Minotaur.DrawEngines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Enumerations;
    using GameSprites;
    using GameSprites.Mobs;
    using GameSprites.Potions;
    using Interfaces;
    using Items;

    public class ConsoleDrawEngine : IDrawEngine
    {
        private const int radius = 100;
        public void DisplayLabyrinth(Labyrinth labyrinth, int visibleAreaX, int visibleAreaY)
        {
            var sb = new StringBuilder();

            for (var row = 0; row < labyrinth.Field.GetLength(0); row++)
            {
                if (!(row >= visibleAreaY - radius && row <= visibleAreaY + radius))
                {
                    continue;
                }
               
                for (var col = 0; col < labyrinth.Field.GetLength(1); col++)
                {
                    if (col >= (visibleAreaX - radius) && col <= (visibleAreaX + radius))
                    {
                        var charToDraw = '#';
                        if (labyrinth.Field[row, col] != CellsEnum.Wall)
                        {
                            charToDraw = ' ';
                        }
                      
                        sb.Append(charToDraw);
                    }
                
                }
                Console.SetCursorPosition(visibleAreaX - radius < 0 ? 0 : visibleAreaX - radius, row);
                Console.Write(sb);
                sb.Clear();
                //sb.AppendLine();
            }

          
           // Console.WriteLine(sb);
        }

        public void DisplayText(int x, int y, string text, ConsoleColor color)
        {
            this.PrintStringAtPosition(x, y, text, color);
        }

        public void DisplayPlayer(Player player)
        {
            this.PrintStringAtPosition(player.Position.X, player.Position.Y, player.DisplayChar.ToString(), ConsoleColor.White);
        }

        public void DisplayPotion(IEnumerable<Potion> potions, int x, int y)
        {
            foreach (var potion in potions)
            {
                if (potion.Position.X >= (x - radius) && potion.Position.X <= (x + radius))
                {
                    if (potion.Position.Y >= (y - radius) && potion.Position.Y <= (y + radius))
                    {
                        this.PrintStringAtPosition(potion.Position.X, potion.Position.Y, potion.Character.ToString(), ConsoleColor.Green);
                    }
                }
            }
        }

        public void DisplayMobs(IEnumerable<GameSprite> mobs, int x, int y)
        {
            foreach (var mob in mobs)
            {
                if (mob.Position.X >= (x - radius) && mob.Position.X <= (x + radius))
                {
                    if (mob.Position.Y >= (y - radius) && mob.Position.Y <= (y + radius))
                    {
                        this.PrintStringAtPosition(mob.Position.X, mob.Position.Y, mob.DisplayChar.ToString(), ConsoleColor.Red);
                    }
                }
            }
        }

        public void DisplayItems(IEnumerable<Item> items, int x, int y)
        {
            foreach (var item in items)
            {
                if (item.Position.X >= (x - radius) && item.Position.X <= (x + radius))
                {
                    if (item.Position.Y >= (y - radius) && item.Position.Y <= (y + radius))
                    {
                        this.PrintStringAtPosition(item.Position.X, item.Position.Y, item.DisplayChar.ToString(), ConsoleColor.Yellow);
                    }
                }
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
