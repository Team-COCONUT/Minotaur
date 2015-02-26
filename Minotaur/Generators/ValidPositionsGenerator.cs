namespace Minotaur.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Minotaur.Enumerations;

    public static class ValidPositionsGenerator
    {
        private static Random random = new Random();

        public static IList<Coords> Generate(Labyrinth labyrinth, int positionsCount)
        {
            IList<Coords> validCoords = new List<Coords>();

            Console.WriteLine(labyrinth);
            while (validCoords.Count < positionsCount)
            {
                var x = random.Next(0, labyrinth.Field.GetLength(1));
                var y = random.Next(0, labyrinth.Field.GetLength(0));

                if (labyrinth.Field[y, x] == CellsEnum.Empty)
                {
                    validCoords.Add(new Coords(x, y));
                }
            }

            return validCoords.ToList();
        }
    }
}
