namespace Minotaur.GameSprites.Mobs
{
    public class Harpy : Mob
    {
        private const int DefaultHealth = 10;
        private const int DefaultAttack = 25;
        private const int DefaultDefense = 5;
        private const char Char = 'h';

        public Harpy()
            : this(position: new Coords(0, 0))
        {
        }

        public Harpy(Coords position,
                     int healthPoints = DefaultHealth,
                     int attackPoints = DefaultAttack,
                     int defensePoints = DefaultDefense)
            : base(position, healthPoints, attackPoints, defensePoints, Char)
        {
        }
    }
}
