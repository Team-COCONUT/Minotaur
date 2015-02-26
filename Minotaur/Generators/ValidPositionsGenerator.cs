namespace Minotaur.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Minotaur.Interfaces;
    using Minotaur.Enumerations;

    public class ValidPositionsGenerator : IGenerator
    {
        private static ValidPositionsGenerator instance = null;
        private Random random = new Random();

        private ValidPositionsGenerator()
	    {
	    }

        public static ValidPositionsGenerator GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ValidPositionsGenerator();
                }

                return instance;
            }
        }

        public IList<Coords> Generate(Labyrinth labyrinth, int positionsCount)
        {
            IList<Coords> validCoords = new List<Coords>();

            Console.WriteLine(labyrinth);
            while (validCoords.Count < positionsCount)
            {
                int x = this.random.Next(0, labyrinth.Field.GetLength(1));
                int y = this.random.Next(0, labyrinth.Field.GetLength(0));

                if (labyrinth.Field[y, x] == CellsEnum.Empty)
                {
                    validCoords.Add(new Coords(x, y));
                }
            }

            return validCoords.ToList();
        }
    }
}
