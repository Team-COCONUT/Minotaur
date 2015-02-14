namespace Minotaur.GameSprites
{
    using System.Collections.Generic;

    public class Player : GameSprite
    {
        private ICollection<Item> inventory;

        public Player(Coords position, int healthPoints, int attackPoints, ICollection<Item> inventory,int defensePoints, int playerSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, playerSpeed)
        {
            this.Inventory = inventory;
        }

        public ICollection<Item> Inventory
        {
            get 
            {
                return new List<Item>(inventory);
            }

            private set
            {
                inventory = value;
            }
        }
    }
}
