namespace Minotaur.Items
{
    public class BattleAxe : Item
    {
        private const int AxeAttack = 5;
        private const int AxeDefense = 3;
        private const int Speed = 0; 

        public BattleAxe()
            : base(Speed, AxeDefense, AxeAttack)
        {
        }
    }
}
