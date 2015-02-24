namespace Minotaur.Items
{
   public class BootsOfSwiftness : Item
    {
        private const int BootAttack = 0;
        private const int BootDefense = 1;
        private const int Speed = 2;

        public BootsOfSwiftness()
            : base(Speed, BootDefense, BootAttack)
        {
        }
    }
}
