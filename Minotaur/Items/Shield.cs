namespace Minotaur.Items
{
   public class Shield : Item
    {
        private const int ShieldAttack = -1;
        private const int ShieldDefense = 5;
        private const int Speed = -2;

        public Shield()
            : base(Speed, ShieldDefense,  ShieldAttack)
        {
        }
    }
}
