namespace Minotaur.Artifacts.Items
{
    public class BattleAxe : Item
    {
        private const int AxeAttack = 5;
        private const int AxeDefense = 3;
        private const char Char = 'A';

        public BattleAxe()
            : this(position: new Coords(0, 0))
        {
        }

        public BattleAxe(Coords position, 
            int attackEffect = AxeAttack, 
            int defenseEffect = AxeDefense, 
            char displayChar = Char) 
            : base(position, attackEffect, defenseEffect, displayChar)
        {
        }
    }
}
