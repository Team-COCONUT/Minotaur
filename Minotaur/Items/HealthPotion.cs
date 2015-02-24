namespace Minotaur.Items
{
    using System;

    using Interfaces;

    public class HealthPotion : IHealthPotion
    {
        private int healthEffect;

        public HealthPotion(int healthEffect)
        {
            this.HealthEffect = healthEffect;
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Health effect must be greter than zero !");
                }

                this.healthEffect = value;
            }
        }
    }
}
