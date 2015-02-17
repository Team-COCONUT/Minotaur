using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaur.Items
{
   public class Shield:Item
    {
        private const int SHIELD_ATTACK = -1;
        private const int SHIELD_DEFENSE = 5;
        private const int SPEED = -2;
        public Shield()
            : base(SPEED, SHIELD_DEFENSE,  SHIELD_ATTACK)
        {
        }
    }
}
