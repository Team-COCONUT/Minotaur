namespace Minotaur.GameSprites.Potions
{
    using System;

    public class AttackPotion : Potion
    {
        private const char Char = 'A';

        public AttackPotion()
            : this(position: new Coords(0, 0), attackEffect: 10)
        {
        }

        public AttackPotion(Coords position, int attackEffect, char character = Char)
        {
            this.AttackEffect = attackEffect;
            this.Position = position;
            this.Character = character;
        }
    }
}
