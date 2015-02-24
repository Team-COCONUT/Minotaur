namespace Minotaur.GameSprites
{
    using System;

    public abstract class GameSprite
    {
        private Coords position;
        private int healthPoints;
        private int attackPoints;
        private int defensePoints;
        private int speed;
        private Random random;

        public GameSprite(Coords position, int healthPoints, int attackPoints, int defensePoints, int speed)
        {
            this.Position = position;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.SpeedPoints = speed;
            this.random = new Random();
        }

        public int HealthPoints
        {
            get 
            {
                return this.healthPoints; 
            }

            set 
            {
                this.healthPoints = value;
            }
        }

        public int DefensePoints
        {
            get 
            {
                return this.defensePoints;
            }

            set 
            {
                this.defensePoints = value;
            }
        }

        public int SpeedPoints 
        {
            get 
            {
                return this.speed;
            }

            set
            {
                this.speed = value;
            }
        }

        public int AttackPoints
        {
            get 
            {
                return this.attackPoints;
            }

            set 
            {
                this.attackPoints = value;
            }
        }

        public Coords Position
        {
            get
            {
                return this.position;
            }

            protected set
            {
                this.position = value;
            }
        }

        public void ChangePosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        public int Attack()
        {
            return this.random.Next(50, this.AttackPoints + 1);
        }
    }
}
