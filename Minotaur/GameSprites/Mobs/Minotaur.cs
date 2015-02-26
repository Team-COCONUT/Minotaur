namespace Minotaur.GameSprites.Mobs
{
    public class Minotaur : Mob
    {
        private const char Char = '@';
     
        public Minotaur(Coords position, int healthPoints, int attackPoints, int defensePoints)
            : base(position, healthPoints, attackPoints, defensePoints, Char)
        {
        }
    }
}
