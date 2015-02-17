namespace Minotaur
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Labyrinth
    {
        public Labyrinth(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Cells = new CellState[this.Width, this.Height];

            this.InitializeLabyrinth();
            this.RandomNumberGenerator = new Random();
            this.VisitCell(this.RandomNumberGenerator.Next(width), this.RandomNumberGenerator.Next(height));
        }

        private void InitializeLabyrinth()
        {
            for (var row = 0; row < this.Width; row++)
            {
                for (var col = 0; col < this.Height; col++)
                {
                    this.Cells[row, col] = CellState.Initial;
                }
            }
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public CellState[,] Cells { get; set; }

        public Random RandomNumberGenerator { get; set; }

        public CellState this[int row, int col]
        {
            get 
            { 
                return this.Cells[row, col];
            }

            set 
            {
                this.Cells[row, col] = value;
            }
        }

        private IEnumerable<RemoveWallAction> GetNeighbours(Point p)
        {
            if (p.X > 0)
            {
                yield return new RemoveWallAction
                {
                    Neighbour = new Point(p.X - 1, p.Y),
                    Wall = CellState.Left
                };
            }

            if (p.Y > 0)
            {
                yield return new RemoveWallAction
                {
                    Neighbour = new Point(p.X, p.Y - 1),
                    Wall = CellState.Top
                };
            }

            if (p.X < this.Width - 1)
            {
                yield return new RemoveWallAction
                {
                    Neighbour = new Point(p.X + 1, p.Y),
                    Wall = CellState.Right
                };
            }

            if (p.Y < this.Height - 1)
            {
                yield return new RemoveWallAction
                {
                    Neighbour = new Point(p.X, p.Y + 1),
                    Wall = CellState.Bottom
                };
            }
        }

        private void VisitCell(int row, int col)
        {
            this[row, col] |= CellState.Visited;
            var cells = GetNeighbours(new Point(row, col))
                        .Shuffle(this.RandomNumberGenerator)
                        .Where(z => !(this[z.Neighbour.X, z.Neighbour.Y].HasFlag(CellState.Visited)));
            foreach (var p in cells)
            {
                this[row, col] -= p.Wall;
                this[p.Neighbour.X, p.Neighbour.Y] -= p.Wall.OppositeWall();
                this.VisitCell(p.Neighbour.X, p.Neighbour.Y);
            }
        }
    }
}
