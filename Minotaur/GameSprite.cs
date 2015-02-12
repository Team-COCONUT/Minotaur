namespace Minotaur
{
    public abstract class GameSprite
    {
        private int x;
        private int y;
        private int healthPoints;
        private int attackPoints;

        public GameSprite(int x, int y, int healthPoints, int attackPoints)
        {
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.X = x;
            this.Y = y;
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            set { healthPoints = value; }
        }

        public int AttackPoints
        {
            get { return attackPoints; }
            set { attackPoints = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
