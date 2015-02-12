using Minotaur.Interfaces;

namespace Minotaur
{
    public abstract class Item : IUsable, IEquippable
    {
        protected Item(int healthEffect, int defenseEffect, int attackEffect)
        {
            this.HealthEffect = healthEffect;
            this.DefenseEffect = defenseEffect;
            this.AttackEffect = attackEffect;
        }

        public int HealthEffect { get; set; }

        public int DefenseEffect { get; set; }

        public int AttackEffect { get; set; }
    }
}
