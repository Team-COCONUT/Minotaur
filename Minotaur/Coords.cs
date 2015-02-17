namespace Minotaur
{
    public struct Coords
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coords(int x, int y) 
            : this()
        {
            this.X = x;
            this.Y = y;
        }
    }
}
