using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MazeGeneration
{
<<<<<<< HEAD
    public static class Extensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            var e = source.ToArray();
            for (var i = e.Length - 1; i >= 0; i--)
            {
                var swapIndex = rng.Next(i + 1);
                yield return e[swapIndex];
                e[swapIndex] = e[i];
            }
        }

        public static CellState OppositeWall(this CellState orig)
        {
            return (CellState)(((int)orig >> 2) | ((int)orig << 2)) & CellState.Initial;
        }
    }

    [Flags]
    public enum CellState
    {
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8,
        Visited = 128,
        Initial = Top | Right | Bottom | Left,
    }

    public struct RemoveWallAction
    {
        public Point Neighbour;
        public CellState Wall;
    }

    public class Maze
    {
        private readonly CellState[,] _cells;
        private readonly int _width;
        private readonly int _height;
        private readonly Random _rng;

        public Maze(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new CellState[width, height];
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    _cells[x, y] = CellState.Initial;
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
            if (p.X > 0) yield return new RemoveWallAction { Neighbour = new Point(p.X - 1, p.Y), Wall = CellState.Left };
            if (p.Y > 0) yield return new RemoveWallAction { Neighbour = new Point(p.X, p.Y - 1), Wall = CellState.Top };
            if (p.X < _width - 1) yield return new RemoveWallAction { Neighbour = new Point(p.X + 1, p.Y), Wall = CellState.Right };
            if (p.Y < _height - 1) yield return new RemoveWallAction { Neighbour = new Point(p.X, p.Y + 1), Wall = CellState.Bottom };
        }

        public void VisitCell(int x, int y)
        {
            this[x, y] |= CellState.Visited;
            foreach (var p in GetNeighbours(new Point(x, y)).Shuffle(_rng).Where(z => !(this[z.Neighbour.X, z.Neighbour.Y].HasFlag(CellState.Visited))))
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
                    firstLine = sbTop.ToString();
                Debug.WriteLine(sbTop + "+");
                Debug.WriteLine(sbMid + "|");
                Debug.WriteLine(sbMid + "|");
            }
            Debug.WriteLine(firstLine);
        }
    }
=======
    using System;

    using Minotaur.DrawEngines;
    using Minotaur.Interfaces;
    using Minotaur.Items;
>>>>>>> 2a3ba0e624c4ac1b0c750867294c3bf9069fb697

    class Program
    {
        private static IDrawEngine drawEngine = new ConsoleDrawEngine();

        static void Main()
        {
<<<<<<< HEAD
            var maze = new Maze(20, 20);
            maze.Display();
=======
            BattleAxe a = new BattleAxe();
          
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.SetWindowSize(120, 50);
            Console.SetBufferSize(120, 50);
            var maze = new Labyrinth(26, 10);
            drawEngine.DisplayLabyrinth(maze);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                drawEngine.DisplayText(i, 37, "=", ConsoleColor.Green);
                drawEngine.DisplayText(i, 31, "=", ConsoleColor.Green);
            }

            drawEngine.DisplayText(2, 32, "Lives: ", ConsoleColor.Green);
            drawEngine.DisplayText(15, 32, "Score: ", ConsoleColor.Green);
            Console.WriteLine();
>>>>>>> 2a3ba0e624c4ac1b0c750867294c3bf9069fb697
        }
    }
}
