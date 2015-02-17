using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaur.Items
{
   public class BootsOfSwiftness:Item
    {
        private const int BOOT_ATTACK = 0;
        private const int BOOT_DEFENSE = 1;
        private const int SPEED = 2;
        public BootsOfSwiftness()
            : base(SPEED, BOOT_DEFENSE, BOOT_ATTACK)
        {
        }
    }
}
