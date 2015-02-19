namespace Minotaur.Interfaces
{
    using Minotaur.GameSprites;
    using System;

    public interface IDrawEngine
    {
        void DisplayLabyrinth();
        void DisplayText(int x, int y, string text, ConsoleColor color);
        void DisplayPlayer(Player player);
    }
}
