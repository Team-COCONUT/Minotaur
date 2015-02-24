namespace Minotaur.GameSprites.Mobs
{
    public class Harpy : Mob
    {
        private const int Health = 100;
        private const int Attack = 30;
        private const int Defense = 50;
        private const int MobSpeed = 0;
        private const char Char = 'w';

        public Harpy(Coords position, 
                     int healthPoints = Health, 
                     int attackPoints = Attack,
                     int defensePoints = Defense, 
                     int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, Char)
        {
        }
    }
}
