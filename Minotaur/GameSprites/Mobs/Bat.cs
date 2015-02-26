namespace Minotaur.GameSprites.Mobs
{
    public class Bat : Mob
    {
        private const int DefaultHealth = 10;
        private const int DefaultAttack = 10;
        private const int DefaultDefense = 5;
        private const char Char = 'b';

        public Bat()
            : this(position: new Coords(0, 0))
        {
        }

        public Bat(Coords position,
                   int healthPoints = DefaultHealth,
                   int attackPoints = DefaultAttack,
                   int defensePoints = DefaultDefense)
            : base(position, healthPoints, attackPoints, defensePoints, Char)
        {
        }
    }
}
