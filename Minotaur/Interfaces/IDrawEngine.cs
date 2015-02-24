namespace Minotaur.Interfaces
{
    using System;

    using GameSprites;

    public interface IDrawEngine
    {
        void DisplayLabyrinth(Labyrinth labyrinth);
        void DisplayText(int x, int y, string text, ConsoleColor color);
        void DisplayPlayer(Player player);
    }
}
