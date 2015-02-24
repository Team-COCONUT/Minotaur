namespace Minotaur
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

    //    public static CellState OppositeWall(this CellState orig)
    //    {
    //        return (CellState)(((int)orig >> 2) | ((int)orig << 2)) & CellState.Initial;
    //    }
    }
}