namespace Minotaur.GameSprites.Mobs
{
    public class Harpy : Mob
    {
        private const int DefaultHealth = 100;
        private const int DefaultAttack = 30;
        private const int DefaultDefense = 50;
        private const int MobSpeed = 0;
        private const char Char = 'h';

        public Harpy()
            : this(position: new Coords(0, 0))
        {
        }

        public Harpy(Coords position,
                     int healthPoints = DefaultHealth,
                     int attackPoints = DefaultAttack,
                     int defensePoints = DefaultDefense, 
                     int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, Char)
        {
        }
    }
}
