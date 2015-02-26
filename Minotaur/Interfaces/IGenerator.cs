namespace Minotaur.Interfaces
{
    using System.Collections.Generic;

    public interface IGenerator
    {
        IList<Coords> Generate(Labyrinth labyrinth, int positionsCount);
    }
}
