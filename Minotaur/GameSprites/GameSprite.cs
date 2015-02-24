namespace Minotaur.GameSprites
{
    using System;

    using Enumerations;

    public abstract class GameSprite
    {
        private Coords position;
        private int healthPoints;
        private int attackPoints;
        private int defensePoints;
        private int speed;
        private Random random;

        public GameSprite(Coords position, int healthPoints, int attackPoints, int defensePoints, int speed, char displayChar)
        {
            this.Position = position;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.SpeedPoints = speed;
            this.DisplayChar = displayChar;
            this.random = new Random();
        }

        public char DisplayChar { get; set; }

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

        public bool IsAlive()
        {
            return this.HealthPoints > 0;
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

        public virtual void CheckPosition(Coords currPosition, Labyrinth labyrinth)
        {
            var isXInMatrix = currPosition.X >= 0 && currPosition.X < labyrinth.Field.GetLength(1);
            var isYInMatrix = currPosition.Y >= 0 && currPosition.Y < labyrinth.Field.GetLength(0);

            if (isXInMatrix && isYInMatrix)
            {
                if (labyrinth.Field[currPosition.Y, currPosition.X] == CellsEnum.Empty)
                {
                    this.ChangePosition(currPosition.X, currPosition.Y);
                }
            }
        }

        public override string ToString()
        {
            return String.Format("health: {0}, attack: {1}, defence: {2}, speed: {3}",
                this.HealthPoints, this.AttackPoints, this.DefensePoints, this.SpeedPoints);
        }
    }
}
