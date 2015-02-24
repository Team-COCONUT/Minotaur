namespace Minotaur.GameSprites.Mobs
{
    public class Hydra : Mob
    {
        private const int Health = 100;
        private const int Attack = 70;
        private const int Defense = 90;
        private const int MobSpeed = 0;

        public Hydra(Coords position, 
                     int healthPoints = Health, 
                     int attackPoints = Attack,
                     int defensePoints = Defense, 
                     int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed)
        {
        }
    }
}
