﻿namespace Minotaur.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Minotaur.Interfaces;
    using Minotaur.Enumerations;

    public static class ValidPositionsGenerator
    {
        private static Random random = new Random();

        public static IList<Coords> Generate(Labyrinth labyrinth, int positionsCount)
        {
            HashSet<Coords> validCoords = new HashSet<Coords>();

            while (validCoords.Count < positionsCount)
            {
                int x = random.Next(0, labyrinth.Field.GetLength(1));
                int y = random.Next(0, labyrinth.Field.GetLength(0));

                if (labyrinth.Field[y, x] == CellsEnum.Empty)
                {
                    validCoords.Add(new Coords(x, y));
                }
            }

            return validCoords.ToList();
        }
    }
}