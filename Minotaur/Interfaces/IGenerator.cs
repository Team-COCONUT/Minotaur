namespace Minotaur.Interfaces
{
    using System.Collections.Generic;

    public interface IGenerator
    {
        IEnumerable<Coords> Generate(Labyrinth labyrinth, int positionsCount);
    }
}
