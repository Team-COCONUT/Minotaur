using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Minotaur
{
    public class Labyrinth
    {
        public Labyrinth(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Cells = new CellState[this.Width, this.Height];

            for (var row = 0; row < this.Width; row++)
            {
                for (var col = 0; col < this.Height; col++)
                {
                    this.Cells[row, col] = CellState.Initial;
                }
            }

            this.RandomNumberGenerator = new Random();
            VisitCell(this.RandomNumberGenerator.Next(width), this.RandomNumberGenerator.Next(height));
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public CellState[,] Cells { get; set; }
        public Random RandomNumberGenerator { get; set; }

        public CellState this[int row, int col]
        {
            get { return this.Cells[row, col]; }
            set { this.Cells[row, col] = value; }
        }

        public IEnumerable<RemoveWallAction> GetNeighbours(Point p)
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

        public void VisitCell(int row, int col)
        {
            this[row, col] |= CellState.Visited;

            foreach (var p in GetNeighbours(new Point(row, col))
                        .Shuffle(this.RandomNumberGenerator)
                        .Where(z => !(this[z.Neighbour.X, z.Neighbour.Y].HasFlag(CellState.Visited))))
            {
                this[row, col] -= p.Wall;
                this[p.Neighbour.X, p.Neighbour.Y] -= p.Wall.OppositeWall();
                VisitCell(p.Neighbour.X, p.Neighbour.Y);
            }
        }

        public void Display()
        {
            var firstLine = string.Empty;

            for (var col = 0; col < this.Height; col++)
            {
                var sbTop = new StringBuilder();
                var sbMid = new StringBuilder();

                for (var row = 0; row < this.Width; row++)
                {
                    sbTop.Append(this[row, col].HasFlag(CellState.Top) ? "+--" : "+  ");
                    sbMid.Append(this[row, col].HasFlag(CellState.Left) ? "|  " : "   ");
                }

                if (firstLine == string.Empty)
                {
                    firstLine = sbTop.ToString();
                }

                Console.WriteLine(sbTop + "+");
                Console.WriteLine(sbMid + "|");
                Console.WriteLine(sbMid + "|");

            }
            Console.WriteLine(firstLine + "+");
        }
    }
}
