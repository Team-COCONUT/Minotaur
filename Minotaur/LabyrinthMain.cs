namespace Minotaur
{
    using System;

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
