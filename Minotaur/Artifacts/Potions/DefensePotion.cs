namespace Minotaur.Artifacts.Potions
{
    public class DefensePotion : Potion
    {
        private const char Char = 'D';

        public DefensePotion(Coords position, int attackEffect, int defenseEffect, char displayChar = Char) 
            : base(position, attackEffect, defenseEffect, displayChar)
        {
        }

        public DefensePotion()
            : this(new Coords(0, 0), 0, 10)
        {
        }
    }
}
