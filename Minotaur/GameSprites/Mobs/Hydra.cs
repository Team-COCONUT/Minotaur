namespace Minotaur.GameSprites.Mobs
{
    public class Hydra : Mob
    {
        private const int DefaultHealth = 100;
        private const int DefaultAttack = 70;
        private const int DefaultDefense = 90;
        private const int MobSpeed = 0;
        private const char Char = 'r';

        public Hydra(Coords position,
                     int healthPoints = DefaultHealth,
                     int attackPoints = DefaultAttack,
                     int defensePoints = DefaultDefense, 
                     int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, Char)
        {
        }
    }
}
