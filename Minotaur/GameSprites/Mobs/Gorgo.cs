namespace Minotaur.GameSprites.Mobs
{
    public class Gorgo : Mob
    {
        private const int Health = 100;
        private const int Attack = 60;
        private const int Defense = 70;
        private const int MobSpeed = 0;
        private const char Char = 'q';

        public Gorgo(Coords position, 
                     int healthPoints = Health, 
                     int attackPoints = Attack,
                     int defensePoints = Defense, 
                     int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, Char)
        {
        }
    }
}
