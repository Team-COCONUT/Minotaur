using Minotaur.Items;

namespace Minotaur.GameSprites
{
    using System.Collections.Generic;

    using Enumerations;

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

        public void Move(Directions direction, Labyrinth labyrinth)
        {
            Coords newPosition = this.Position;

            if (direction == Directions.Up)
            {
                newPosition.Y--;
            }
            else if (direction == Directions.Down)
            {
                newPosition.Y++;
            }
            else if (direction == Directions.Left)
            {
                newPosition.X--;
            }
            else if (direction == Directions.Right)
            {
                newPosition.X++;
            }

            // checking position
            bool isXInMatrix = newPosition.X >= 0 && newPosition.X < labyrinth.Field.GetLength(1);
            bool isYInMatrix = newPosition.Y >= 0 && newPosition.Y < labyrinth.Field.GetLength(0);

            if (isXInMatrix && isYInMatrix)
            {
                if (labyrinth.Field[newPosition.Y, newPosition.X] == CellsEnum.Empty)
                {
                    this.ChangePosition(newPosition.X, newPosition.Y);
                }
            }
        }
    }
}
