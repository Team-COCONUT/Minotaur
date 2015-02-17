namespace Minotaur
{
    public struct Coords
    {
        private int x;
        private int y;

        public Coords(int x, int y) 
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            private set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get 
            {
                return this.y;
            }
            
            private set
            {
                this.y = value;
            }
        }
    }
}
