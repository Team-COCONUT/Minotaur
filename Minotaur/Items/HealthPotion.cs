namespace Minotaur.Items
{
    using System;

    using Interfaces;

    public class HealthPotion : IHealthPotion
    {
        private Coords position;
        private int healthEffect;
        private const char Char = 'o';

        public HealthPotion()
            : this(position: new Coords(0, 0), healthEffect: 0)
        {
        }

        public HealthPotion(Coords position, int healthEffect, char displayChar = Char)
        {
            this.HealthEffect = healthEffect;
            this.Position = position;
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }
            private set
            {
                this.healthEffect = value;
            }
        }

        public Coords Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
