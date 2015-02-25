namespace Minotaur.Interfaces
{
    using System;
    using System.Collections.Generic;

    using GameSprites;
    using GameSprites.Mobs;
    using Items;

    public interface IDrawEngine
    {
        void DisplayLabyrinth(Labyrinth labyrinth, int visibleAreaX, int visibleAreaY);
        void DisplayText(int x, int y, string text, ConsoleColor color);
        void DisplayPlayer(Player player);
        void DisplayMinotaur(Minotaur minotaur, int positionX, int positionY);
        void DisplayHealthPotion(List<HealthPotion> potions,int positionX,int positionY);
        void DisplayMobs(List<Mob> mobs, int positionX, int positionY);
        void DisplayItems(List<Item> items, int positionX, int positionY);
    }
}
