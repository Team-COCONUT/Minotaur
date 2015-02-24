namespace Minotaur.Interfaces
{
    using System;

    using GameSprites;
    using GameSprites.Mobs;
    using Items;

    public interface IDrawEngine
    {
        void DisplayLabyrinth(Labyrinth labyrinth);
        void DisplayText(int x, int y, string text, ConsoleColor color);
        void DisplayPlayer(Player player);
        void DisplayMinotaur(Minotaur minotaur);
        void DisplayHealthPotion(HealthPotion potion);
    }
}
