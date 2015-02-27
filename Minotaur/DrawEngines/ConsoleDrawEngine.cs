namespace Minotaur.DrawEngines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Artifacts.Items;
    using Artifacts.Potions;
    using Enumerations;
    using GameSprites;
    using Interfaces;

    public class ConsoleDrawEngine : IDrawEngine
    {
        private const int radius = 100;
        public void DisplayLabyrinth(Labyrinth labyrinth, int visibleAreaX, int visibleAreaY)
        {
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < labyrinth.Field.GetLength(0); row++)
            {
                if (!(row >= visibleAreaY - radius && row <= visibleAreaY + radius))
                {
                    continue;
                }
               
                for (int col = 0; col < labyrinth.Field.GetLength(1); col++)
                {
                    if (col >= (visibleAreaX - radius) && col <= (visibleAreaX + radius))
                    {
                        char charToDraw = '#';
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
            }

          
           // Console.WriteLine(sb);
        }

        public void DisplayText(int x, int y, string text, ConsoleColor color)
        {
            this.PrintStringAtPosition(x, y, text, color);
        }

        public void DisplayPlayer(Player player)
        {
            this.PrintStringAtPosition(player.Position.X, player.Position.Y, player.DisplayChar.ToString(), ConsoleColor.Magenta);
        }

        public void DisplayPotion(IEnumerable<Potion> potions, int x, int y)
        {
            foreach (Potion potion in potions)
            {
                if (potion.Position.X >= (x - radius) && potion.Position.X <= (x + radius))
                {
                    if (potion.Position.Y >= (y - radius) && potion.Position.Y <= (y + radius))
                    {
                        this.PrintStringAtPosition(potion.Position.X, potion.Position.Y, potion.DisplayChar.ToString(), ConsoleColor.Green);
                    }
                }
            }
        }

        public void DisplayMobs(IEnumerable<GameSprite> mobs, int x, int y)
        {
            foreach (GameSprite mob in mobs)
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
            foreach (Item item in items)
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

        public static void DisplayStickyMsg(string message, string confirmationMsg)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine(confirmationMsg);
            Console.ReadKey();
            Console.Clear();
        }

        public void ClearPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("");
        }

        public void ClearAll()
        {
            Console.Clear();
        }

        private void PrintStringAtPosition(int x, int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
        }
      
    }
}
