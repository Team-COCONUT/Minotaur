namespace Minotaur.GameSprites
{
    using System.Collections.Generic;

    using Enumerations;
    using Items;

    public class Player : GameSprite
    {
        private ICollection<Item> inventory;
        private int money = 0;

        public Player(Coords position, int healthPoints, int attackPoints, ICollection<Item> inventory, int defensePoints, int playerSpeed)
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

        public void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public void RemoveFromInventory(Item item)
        {
            this.Inventory.Add(item);
            RemoveItemEffects(item);
        }

        public void ApplyItemEffects(Item item)
        {
            this.DefensePoints += item.DefenseEffect;
            this.AttackPoints += item.AttackEffect;
            this.SpeedPoints += item.SpeedEffect;
        }

        public void RemoveItemEffects(Item item)
        {
            this.DefensePoints -= item.DefenseEffect;
            this.AttackPoints -= item.AttackEffect;
            this.SpeedPoints -= item.SpeedEffect;
        }

        public void Move(Directions direction, Labyrinth labyrinth)
        {
            var newPosition = this.Position;

            switch (direction)
            {
                case Directions.Up:
                    newPosition.Y--;
                    break;
                case Directions.Down:
                    newPosition.Y++;
                    break;
                case Directions.Left:
                    newPosition.X--;
                    break;
                case Directions.Right:
                    newPosition.X++;
                    break;
            }

            CheckPosition(newPosition, labyrinth);
        }
    }
}
