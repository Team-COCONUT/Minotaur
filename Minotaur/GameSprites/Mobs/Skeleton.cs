namespace Minotaur.GameSprites.Mobs
{
    public class Skeleton : Mob
    {
        private const int DefaultHealth = 100;
        private const int DefaultAttack = 20;
        private const int DefaultDefense = 50;
        private const int MobSpeed = 0;
        private const char Char = 's';

        public Skeleton()
            : this(position: new Coords(0, 0))
        {
        }

        public Skeleton(Coords position,
            int healthPoints = DefaultHealth,
            int attackPoints = DefaultAttack,
            int defensePoints = DefaultDefense,
            int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, Char)
        {
        }
    }
}
