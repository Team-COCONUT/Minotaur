namespace Minotaur.Items
{
    using System;

    using Interfaces;

    public abstract class Item : IEquippable
    {
        protected Item(Coords position, int attackEffect, int defenseEffect, int speedEffect, char displayChar)
        {
            this.SpeedEffect = speedEffect;
            this.DefenseEffect = defenseEffect;
            this.AttackEffect = attackEffect;
            this.DisplayChar = displayChar;
            this.Position = position;
        }

        public char DisplayChar { get; private set; }

        public Coords Position { get; private set; }

        public int SpeedEffect
        {
            get;
            protected set;
        }

        public int DefenseEffect
        {
            get;
            protected set;
        }

        public int AttackEffect
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return String.Format("attack: {0}, defense: {1}, speed: {2}",
                this.AttackEffect, this.DefenseEffect, this.SpeedEffect);
        }
    }
}
