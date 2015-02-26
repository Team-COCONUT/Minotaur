namespace Minotaur.GameSprites.Mobs
{
    public class Skeleton : Mob
    {
        private const int DefaultHealth = 10;
        private const int DefaultAttack = 15;
        private const int DefaultDefense = 5;
        private const char Char = 's';

        public Skeleton()
            : this(position: new Coords(0, 0))
        {
        }

        public Skeleton(Coords position,
            int healthPoints = DefaultHealth,
            int attackPoints = DefaultAttack,
            int defensePoints = DefaultDefense)
            : base(position, healthPoints, attackPoints, defensePoints, Char)
        {
        }
    }
}
