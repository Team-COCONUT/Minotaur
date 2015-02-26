namespace Minotaur.GameSprites.Potions
{
    public class DefensePotion : Potion
    {
        private const char Char = 'D';

        public DefensePotion()
            : this(position: new Coords(0, 0), defenseEffect: 10)
        {
        }

        public DefensePotion(Coords position, int defenseEffect, char character = Char)
        {
            this.DefenseEffect = defenseEffect;
            this.Position = position;
            this.Character = character;
        }
    }
}
