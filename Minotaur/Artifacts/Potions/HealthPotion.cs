namespace Minotaur.Artifacts.Potions
{
    using Interfaces;

    public class HealthPotion : Potion, IHealthPotion
    {
        private const char Char = 'H';

        public HealthPotion(Coords position, int attackEffect, int defenseEffect, int healthEffect, char displayChar = Char) 
            : base(position, attackEffect, defenseEffect, displayChar)
        {
            this.HealthEffect = healthEffect;
        }

        public HealthPotion()
            : this(new Coords(0, 0), 0, 0, 10)
        {
        }

        public int HealthEffect { get; private set; }
    }
}
