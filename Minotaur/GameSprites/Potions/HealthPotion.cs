namespace Minotaur.GameSprites.Potions
{
    using System;

    public class HealthPotion : Potion
    {
        private const char Char = 'H';

        public HealthPotion()
            : this(position: new Coords(0, 0), healthEffect: 10)
        {
        }

        public HealthPotion(Coords position, int healthEffect, char character = Char)
        {
            this.HealthEffect = healthEffect;
            this.Position = position;
            this.Character = character;
        }
    }
}
