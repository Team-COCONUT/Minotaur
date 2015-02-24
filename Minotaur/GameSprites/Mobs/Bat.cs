namespace Minotaur.GameSprites.Mobs
{
    public class Bat : Mob
    {
        private const int DefaultHealth = 100;
        private const int DefaultAttack = 10;
        private const int DefaultDefense = 30;
        private const int MobSpeed = 0;
        private const char Char = 'x';

        public Bat(Coords position,
                   int healthPoints = DefaultHealth,
                   int attackPoints = DefaultAttack,
                   int defensePoints = DefaultDefense, 
                   int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, Char)
        {
        }
    }
}
