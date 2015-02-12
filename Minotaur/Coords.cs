namespace Minotaur
{
    struct Coords
    {
        private readonly int x;
        private readonly int y;

        public Coords(int x, int y) 
            : this()
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }
    }
}
