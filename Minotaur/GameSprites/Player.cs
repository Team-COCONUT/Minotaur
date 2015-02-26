﻿namespace Minotaur.GameSprites
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Enumerations;
    using Items;
    using Interfaces;
    using GameSprites.Potions;

    public class Player : GameSprite, IMovable
    {
        private ICollection<Item> inventory;
        private const char Char = (char)2;

        public Player(Coords position, int healthPoints, int attackPoints, ICollection<Item> inventory, int defensePoints)
            : base(position, healthPoints, attackPoints, defensePoints, Char)
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
            this.Inventory.Remove(item);
            RemoveItemEffects(item);
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
            this.HealthPoints += potion.HealthEffect;
            this.DefensePoints += potion.DefenseEffect;
            this.AttackPoints += potion.AttackEffect;
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

        public override string ToString()
        {
            var baseInfo = base.ToString();
            var items = new StringBuilder();

            foreach (var item in Inventory)
            {
                items.AppendLine(item.ToString());
            }
            return String.Format(baseInfo, items);
        }
    }
}
