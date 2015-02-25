namespace Minotaur.Items
{
   public class Shield : Item
    {
        private const int ShieldAttack = -1;
        private const int ShieldDefense = 5;
        private const int Speed = -2;
        private const char Char = '4';

       public Shield(Coords position, 
           int attackEffect = ShieldAttack, 
           int defenseEffect = ShieldDefense, 
           int speedEffect = Speed, 
           char displayChar = Char) 
           : base(position, attackEffect, defenseEffect, speedEffect, displayChar)
       {
       }
    }
}
