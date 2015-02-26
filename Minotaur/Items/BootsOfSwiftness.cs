namespace Minotaur.Items
{
   public class BootsOfSwiftness : Item
    {
        private const int BootAttack = 0;
        private const int BootDefense = 1;
        private const int Speed = 2;
        private const char Char = 'B';

        public BootsOfSwiftness()
            : this(position: new Coords(0, 0))
        {
        }


       public BootsOfSwiftness(Coords position, 
           int attackEffect = BootAttack, 
           int defenseEffect = BootDefense, 
           int speedEffect = Speed, 
           char displayChar = Char) 
           : base(position, attackEffect, defenseEffect, speedEffect, displayChar)
       {
       }
    }
}
