namespace Minotaur.Artifacts.Potions
{
    public class AttackPotion : Potion
    {
        private const char Char = 'A';

        public AttackPotion(Coords position, int attackEffect, int defenseEffect, char displayChar = Char)
            : base(position, attackEffect, defenseEffect, displayChar)
        {
        }

        public AttackPotion()
            : this(new Coords(0, 0), 10, 0)
        {
        }
    }
}
