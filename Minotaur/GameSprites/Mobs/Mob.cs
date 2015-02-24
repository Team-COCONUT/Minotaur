namespace Minotaur.GameSprites.Mobs
{
    public abstract class Mob : GameSprite
    {
        public Mob(Coords position, int healthPoints, int attackPoints, int defensePoints, int mobSpeed, char displayChar)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, displayChar)
        {
        }
    }
}
