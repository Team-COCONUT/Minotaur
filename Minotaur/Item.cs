using Minotaur.Interfaces;

namespace Minotaur
{
    public abstract class Item :IEquippable
    {    
        protected Item(int speedEffect, int defenseEffect, int attackEffect)
        {
            this.SpeedEffect = speedEffect;
            this.DefenseEffect = defenseEffect;
            this.AttackEffect = attackEffect;
        }     
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
    }
}
