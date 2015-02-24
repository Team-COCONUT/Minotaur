namespace Minotaur.GameSprites.Mobs
{
    public class Bat : Mob
    {
        private const int Health = 100;
        private const int Attack = 10;
        private const int Defense = 30;
        private const int MobSpeed = 0;
        private const char Char = 'x';

        public Bat(Coords position, 
                   int healthPoints = Health, 
                   int attackPoints = Attack,
                   int defensePoints = Defense, 
                   int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, Char)
        {
        }
    }
}
