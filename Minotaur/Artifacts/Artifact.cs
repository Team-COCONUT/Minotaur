namespace Minotaur.Artifacts
{
    using System;

    public abstract class Artifact
    {
         protected Artifact(Coords position, int attackEffect, int defenseEffect, char displayChar)
        {
            this.DefenseEffect = defenseEffect;
            this.AttackEffect = attackEffect;
            this.DisplayChar = displayChar;
            this.Position = position;
        }

        public char DisplayChar { get; private set; }

        public Coords Position { get; set; }

        public int DefenseEffect { get; protected set; }

        public int AttackEffect { get; protected set; }

        public override string ToString()
        {
            return String.Format("attack: {0}, defense: {1}",
                this.AttackEffect, this.DefenseEffect);
        }
    }
}
