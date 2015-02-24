namespace Minotaur.Items
{
    using System;

    using Interfaces;

    public class HealthPotion : IHealthPotion
    {
        private Coords position;
        private int healthEffect;

        public HealthPotion(Coords position, int healthEffect)
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
