namespace Minotaur.GameSprites
{
    public abstract class Mob : GameSprite
    {
        protected Mob(int x, int y, int healthPoints, int attackPoints) 
            : base(x, y, healthPoints, attackPoints)
        {
        }
    }
}
