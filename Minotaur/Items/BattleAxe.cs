namespace Minotaur.Items
{
    class BattleAxe : Item
    {
        private const int AXE_ATTACK = 5;
        private const int AXE_DEFENSE = 3;
        private const int SPEED = 0; 
        public BattleAxe()
            : base(SPEED, AXE_DEFENSE, AXE_ATTACK)
        {
        }
    }
}
