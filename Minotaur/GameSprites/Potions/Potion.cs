namespace Minotaur.GameSprites.Potions
{
    using Interfaces;

    public class Potion : IPotion
    {
        private Coords position;

        private int healthEffect;
        private int defenseEffect;
        private int attackEffect;
        private char character;

        public Potion()
            : this(position: new Coords(0, 0), healthEffect: 0, defenseEffect: 0, attackEffect: 0, character: 'o')
        {
        }

        public Potion(Coords position, int healthEffect, int defenseEffect, int attackEffect, char character)
        {
            this.Position = position;
            this.HealthEffect = healthEffect;
            this.DefenseEffect = defenseEffect;
            this.AttackEffect = attackEffect;
            this.Character = character;
        }

        public Coords Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }

            set
            {
                this.healthEffect = value;
            }
        }

        public int DefenseEffect
        {
            get
            {
                return this.defenseEffect;
            }

            set
            {
                this.defenseEffect = value;
            }
        }

        public int AttackEffect
        {
            get
            {
                return this.attackEffect;
            }

            set
            {
                this.attackEffect = value;
            }
        }

        public char Character
        {
            get
            {
                return this.character;
            }

            set
            {
                this.character = value;
            }
        }
    }
}
