namespace Minotaur.Interfaces
{
    using System;
    using System.Collections.Generic;

    using GameSprites;
    using GameSprites.Mobs;
    using Items;

    public interface IDrawEngine
    {
        void DisplayLabyrinth(Labyrinth labyrinth);
        void DisplayText(int x, int y, string text, ConsoleColor color);
        void DisplayPlayer(Player player);
        void DisplayMinotaur(Minotaur minotaur);
        void DisplayHealthPotion(List<HealthPotion> potions);
        void DisplayMobs(List<Mob> mobs);
        void DisplayItems(List<Item> items);
    }
}
