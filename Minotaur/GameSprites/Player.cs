namespace Minotaur.GameSprites
{
    using System;
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
        public void MoveUp()
        {           
            this.ChangePosition(this.Position.X, this.Position.Y-1);
        }
        public void MoveDown()
        {
            this.ChangePosition(this.Position.X, this.Position.Y+1);
        }
        public void MoveRight()
        {
            this.ChangePosition(this.Position.X+1, this.Position.Y);
        }
        public void MoveLeft()
        {
            this.ChangePosition(this.Position.X-1, this.Position.Y);
        }
        //public void Move(ConsoleKey key, CellState[,] labyrinthMatrix)
        //{
        //    Coords newPosition = this.Position;

        //    if(key == ConsoleKey.UpArrow || key == ConsoleKey.W)
        //    {
        //        newPosition.Y--;
        //    }
        //    else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
        //    {
        //        newPosition.Y++;
        //    }
        //    else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
        //    {
        //        newPosition.X--;
        //    }
        //    else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
        //    {
        //        newPosition.X++;
        //    }

        //    // checking position
        //    bool isXInMatrix = newPosition.X >= 0 && newPosition.X < labyrinthMatrix.GetLength(0);
        //    bool isYInMatrix = newPosition.Y >= 0 && newPosition.Y < labyrinthMatrix.GetLength(1);

        //    if (isXInMatrix && isYInMatrix)
        //    {
        //        //if(labyrinthMatrix[newPosition.Y, newPosition.X].HasFlag(CellState.Visited))
        //        //{
        //            this.ChangePosition(newPosition.X, newPosition.Y);
        //        //}
        //    }
        //}
    }
}
