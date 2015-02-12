using System.Collections.Generic;

namespace Minotaur.GameSprites
{
    public class Player : GameSprite
    {
        private List<Item> inventory;

        public Player(int x, int y, int healthPoints, int attackPoints, List<Item> inventory) 
            : base(x, y, healthPoints, attackPoints)
        {
            this.Inventory = inventory;
        }

        public List<Item> Inventory
        {
            get { return inventory; }
            private set { inventory = value; }
        }
    }
}
