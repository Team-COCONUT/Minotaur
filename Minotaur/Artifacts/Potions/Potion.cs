namespace Minotaur.Artifacts.Potions
{
    using Artifacts;

    public class Potion : Artifact
    {
        protected Potion(Coords position, int attackEffect, int defenseEffect, char displayChar) 
            : base(position, attackEffect, defenseEffect, displayChar)
        {
        }
    }
}
