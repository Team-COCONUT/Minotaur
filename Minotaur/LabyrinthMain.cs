namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using Artifacts.Items;
    using Artifacts.Potions;
    using DrawEngines;
    using GameSprites;
    using GameSprites.Mobs;
    using Interfaces;
    using Generators;

    public class LabyrinthMain
    {
        public static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 49;
            Console.BufferWidth = Console.WindowWidth = 81;
            Console.SetWindowSize(80, 49);
            Console.SetBufferSize(80, 49);

            GameEngine engine = new GameEngine();
            engine.Run();
        }
    }
}
