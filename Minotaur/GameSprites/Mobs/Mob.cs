namespace Minotaur.GameSprites.Mobs
{
    public abstract class Mob : GameSprite
    {
        public Mob(Coords position, int healthPoints, int attackPoints, int defensePoints, char displayChar)
            : base(position, healthPoints, attackPoints, defensePoints, displayChar)
        {
        }
    }
}
