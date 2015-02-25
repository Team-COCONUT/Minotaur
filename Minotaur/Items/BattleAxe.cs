namespace Minotaur.Items
{
    public class BattleAxe : Item
    {
        private const int AxeAttack = 5;
        private const int AxeDefense = 3;
        private const int Speed = 0;
        private const char Char = '7';

        public BattleAxe(Coords position, 
            int attackEffect = AxeAttack, 
            int defenseEffect = AxeDefense, 
            int speedEffect = Speed, 
            char displayChar = Char) 
            : base(position, attackEffect, defenseEffect, speedEffect, displayChar)
        {
        }
    }
}
