namespace Minotaur.GameSprites.Mobs
{
    public class Gorgo : Mob
    {
        private const int DefaultHealth = 100;
        private const int DefaultAttack = 60;
        private const int DefaultDefense = 70;
        private const int MobSpeed = 0;
        private const char Char = 'q';

        public Gorgo(Coords position,
                     int healthPoints = DefaultHealth,
                     int attackPoints = DefaultAttack,
                     int defensePoints = DefaultDefense, 
                     int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, Char)
        {
        }
    }
}
