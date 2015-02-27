namespace Minotaur.Artifacts.Items
{
    using Artifacts;

    public abstract class Item : Artifact
    {
        protected Item(Coords position, int attackEffect, int defenseEffect, char displayChar) 
            : base(position, attackEffect, defenseEffect, displayChar)
        {
        }
    }
}
