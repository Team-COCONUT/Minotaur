namespace Minotaur.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Artifacts.Items;
    using Artifacts.Potions;
    using GameSprites;

    public interface IDrawEngine
    {
        void DisplayLabyrinth(Labyrinth labyrinth, int visibleAreaX, int visibleAreaY);
        void DisplayText(int x, int y, string text, ConsoleColor color);
        void DisplayPlayer(Player player);
        void DisplayPotion(IEnumerable<Potion> potions,int positionX, int positionY);
        void DisplayMobs(IEnumerable<GameSprite> mobs, int positionX, int positionY);
        void DisplayItems(IEnumerable<Item> items, int positionX, int positionY);
        void ClearPosition(int x, int y);
        void ClearAll();
    }
}
