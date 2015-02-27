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
        private Random random;

        public GameSprite(Coords position, int healthPoints, int attackPoints, int defensePoints, char displayChar)
        {
            this.Position = position;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
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

            set
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
            return (int)((this.random.Next(50, 101) / 100.0) * this.AttackPoints);
        }

        public int Defend()
        {
            return (int)((this.random.Next(1, 100) / 100.0) * this.DefensePoints);
        }

        public virtual void CheckPosition(Coords currPosition, Labyrinth labyrinth)
        {
            bool isXInMatrix = currPosition.X >= 0 && currPosition.X < labyrinth.Field.GetLength(1);
            bool isYInMatrix = currPosition.Y >= 0 && currPosition.Y < labyrinth.Field.GetLength(0);

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
            return String.Format("health: {0}, attack: {1}, defence: {2}",
                this.HealthPoints, this.AttackPoints, this.DefensePoints);
        }
    }
}
