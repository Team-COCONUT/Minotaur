namespace Minotaur.GameSprites
{
    public abstract class Mob : GameSprite
    {
        public Mob(Coords position, int healthPoints, int attackPoints) 
            : base(position, healthPoints, attackPoints)
        {
        }
    }
}
