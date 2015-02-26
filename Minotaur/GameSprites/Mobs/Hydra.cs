namespace Minotaur.GameSprites.Mobs
{
    public class Hydra : Mob
    {
        private const int DefaultHealth = 10;
        private const int DefaultAttack = 30;
        private const int DefaultDefense = 5;
        private const int MobSpeed = 0;
        private const char Char = 'y';

        public Hydra()
            : this(position: new Coords(0, 0))
        {
        }

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
