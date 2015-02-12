using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Minotaur
{
    public class Labyrinth
    {
        private readonly CellState[,] _cells;
        private readonly int _width;
        private readonly int _height;
        private readonly Random _rng;

        public Labyrinth(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new CellState[width, height];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    _cells[x, y] = CellState.Initial;
                }
            }
            _rng = new Random();
            VisitCell(_rng.Next(width), _rng.Next(height));
        }

        public CellState this[int x, int y]
        {
            get { return _cells[x, y]; }
            set { _cells[x, y] = value; }
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
            if (p.X < _width - 1)
            {
                yield return new RemoveWallAction
                {
                    Neighbour = new Point(p.X + 1, p.Y),
                    Wall = CellState.Right
                };
            }
            if (p.Y < _height - 1)
            {
                yield return new RemoveWallAction
                {
                    Neighbour = new Point(p.X, p.Y + 1),
                    Wall = CellState.Bottom
                };
            }
        }

        public void VisitCell(int x, int y)
        {
            this[x, y] |= CellState.Visited;
            foreach (var p in GetNeighbours(new Point(x, y))
                        .Shuffle(_rng)
                        .Where(z => !(this[z.Neighbour.X, z.Neighbour.Y].HasFlag(CellState.Visited))))
            {
                this[x, y] -= p.Wall;
                this[p.Neighbour.X, p.Neighbour.Y] -= p.Wall.OppositeWall();
                VisitCell(p.Neighbour.X, p.Neighbour.Y);
            }
        }

        public void Display()
        {
            var firstLine = string.Empty;
            for (var y = 0; y < _height; y++)
            {
                var sbTop = new StringBuilder();
                var sbMid = new StringBuilder();
                for (var x = 0; x < _width; x++)
                {
                    sbTop.Append(this[x, y].HasFlag(CellState.Top) ? "+--" : "+  ");
                    sbMid.Append(this[x, y].HasFlag(CellState.Left) ? "|  " : "   ");
                }
                if (firstLine == string.Empty)
                {
                    firstLine = sbTop.ToString();
                }
                Console.WriteLine(sbTop + "+");
                Console.WriteLine(sbMid + "|");
                Console.WriteLine(sbMid + "|");

            }
            Console.WriteLine(firstLine);
        }
    }
}
