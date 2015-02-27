namespace Minotaur.GameSprites
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using Artifacts.Items;
    using Artifacts.Potions;
    using Enumerations;
    using Interfaces;

    public class Player : GameSprite, IMovable, IEquippable, IDrinkable
    {
        private ICollection<Item> inventory;
        private const char Char = (char)2;

        public Player(Coords position, int healthPoints, int attackPoints, int defensePoints, ICollection<Item> inventory)
            : base(position, healthPoints, attackPoints, defensePoints, Char)
        {
            this.Inventory = inventory;
        }

        public ICollection<Item> Inventory
        {
            get
            {
                return this.inventory;
            }

            private set
            {
                inventory = value;
            }
        }

        public void AddToInventory(Item item)
        {
            
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public void ApplyItemEffects(Item item)
        {
            this.DefensePoints += item.DefenseEffect;
            this.AttackPoints += item.AttackEffect;
        }

        public void RemoveItemEffects(Item item)
        {
            this.DefensePoints -= item.DefenseEffect;
            this.AttackPoints -= item.AttackEffect;
        }

        public void ApplyPotionEffect(Potion potion)
        {
            if (potion is HealthPotion)
            {
                HealthPotion healthPotion = potion as HealthPotion;
                this.HealthPoints += healthPotion.HealthEffect;
            }

            this.DefensePoints += potion.DefenseEffect;
            this.AttackPoints += potion.AttackEffect;
        }

        public void Move(Directions direction, Labyrinth labyrinth)
        {
            Coords newPosition = this.Position;

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

            this.CheckPosition(newPosition, labyrinth);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            var itemsInInventory = this.Inventory.Select(i => i.GetType().Name);
            result.Append(string.Format(" Items: [{0}]", string.Join(", ", itemsInInventory)));
            return result.ToString();
        }
    }
}
