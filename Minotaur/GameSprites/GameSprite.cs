namespace Minotaur.GameSprites
{
    public abstract class GameSprite
    {
        private Coords position;
        private int healthPoints;
        private int attackPoints;

        public GameSprite(Coords position, int healthPoints, int attackPoints)
        {
            this.Position = position;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
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

        public Coords Position
        {
            get
            {
                return this.position;
            }

            private set
            {
                this.position = value;
            }
        }
    }
}
