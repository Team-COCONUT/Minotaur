namespace Minotaur.GameSprites.Mobs
{
    public abstract class Mob : GameSprite
    {
        public Mob(Coords position, int healthPoints, int attackPoints, int defensePoints, int mobSpeed, char displayChar)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed, displayChar)
        {
        }

        public override int Attack(GameSprite sprite)
        {
            var player = sprite as Player;
            return this.HealthPoints -= player.AttackPoints - this.DefensePoints;
        }
    }
}
