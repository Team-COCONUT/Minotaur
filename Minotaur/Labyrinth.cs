namespace Minotaur
{
    using System;
    using System.Collections.Generic;

    using Enumerations;

    public class Labyrinth
    {
        private bool[,] visitedCells;
        private CellsEnum[,] field;
        private int currRow = 0;
        private int currCol = 0;
        private int visited;
        private Stack<int> rowStack;
        private Stack<int> colStack;
        private Random random;

        public Labyrinth(int height, int width)
        {
            this.visitedCells = new bool[height, width];
            this.Field = new CellsEnum[height, width];
            this.visited = height * width;
            this.rowStack = new Stack<int>();
            this.colStack = new Stack<int>();
            this.random = new Random();
        }

        public CellsEnum[,] Field 
        {
            get 
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
        }

        private List<int[]> GetAvailableCells(int currentRow, int currentCol, bool[,] visitedCells)
        {
            int[] left = new int[2] { 0, -1 };
            int[] right = new int[2] { 0, 1 };
            int[] up = new int[2] { -1, 0 };
            int[] down = new int[2] { 1, 0 };

            int[][] directions = new int[][] { left, right, up, down };
            List<int[]> availableDirrections = new List<int[]>();

            foreach (int[] direction in directions)
            {
                if (currentCol + direction[1] < visitedCells.GetLength(1) &&
                    currentCol + direction[1] >= 0 &&
                    currentRow + direction[0] < visitedCells.GetLength(0) &&
                    currentRow + direction[0] >= 0 &&
                    !visitedCells[direction[0] + currentRow, direction[1] + currentCol])
                {
                    availableDirrections.Add(new int[] { currentRow + direction[0], currentCol + direction[1] });
                }
            }

            return availableDirrections;
        }

        public void Generate()
        {
            while (visited > 0)
            {
                if (!visitedCells[currRow, currCol])
                {
                    visitedCells[currRow, currCol] = true;
                    field[currRow, currCol] = CellsEnum.Empty;
                    visited--;
                }

                List<int[]> availableDIrections = GetAvailableCells(currRow, currCol, visitedCells);
                if (availableDIrections.Count > 0)
                {
                    int[] randomDirecgtion = availableDIrections[random.Next(0, availableDIrections.Count)];
                    currRow = randomDirecgtion[0];
                    currCol = randomDirecgtion[1];
                    rowStack.Push(randomDirecgtion[0]);
                    colStack.Push(randomDirecgtion[1]);

                    List<int[]> walls = GetAvailableCells(currRow, currCol, visitedCells);
                    if (walls.Count > 1)
                    {
                        int[] randomWall = walls[random.Next(0, walls.Count)];
                        field[randomWall[0], randomWall[1]] = CellsEnum.Wall;
                        visitedCells[randomWall[0], randomWall[1]] = true;
                        visited--;
                    }
                }
                else if (rowStack.Count > 0)
                {
                    currRow = rowStack.Pop();
                    currCol = colStack.Pop();
                }
                else
                {
                    for (int row = 0; row < visitedCells.GetLength(0); row++)
                    {
                        for (int col = 0; col < visitedCells.GetLength(1); col++)
                        {
                            if (visitedCells[row, col] == false)
                            {
                                currRow = row;
                                currCol = col;
                                visited--;
                            }
                        }
                    }
                }
            }

            //Player starting position
            this.Field[1, 1] = CellsEnum.Empty;

            //Minatour starting position
            this.Field[this.Field.GetLength(0) - 1, this.Field.GetLength(1) - 1] = CellsEnum.Empty;
        }      
    }
}
