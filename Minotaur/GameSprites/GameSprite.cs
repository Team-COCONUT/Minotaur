namespace Minotaur.GameSprites
{
    public abstract class GameSprite
    {
        private Coords position;
        private int healthPoints;
        private int attackPoints;
        private int defensePoints;
        private int speed;

        public GameSprite(Coords position, int healthPoints, int attackPoints,int defensePoints,int speed)
        {
            this.Position = position;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Speed = speed;
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            set { healthPoints = value; }
        }
        public int DefensePoints { get; set; }
        public int Speed { get; set; }

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
