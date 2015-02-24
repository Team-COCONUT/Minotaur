using System;
using Minotaur.Enumerations;

namespace Minotaur.GameSprites.Mobs
{
    public class Skeleton : Mob
    {
        private const int Health = 100;
        private const int Attack = 20;
        private const int Defense = 50;
        private const int MobSpeed = 0;

        public Skeleton(Coords position,
            int healthPoints = Health,
            int attackPoints = Attack, 
            int defensePoints = Defense,
            int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed)
        {
        }

        public void Move(Labyrinth labyrinth)
        {
            var newPosition = this.Position;
            var rnd = new Random();
            newPosition.X = rnd.Next(3) - 1;
            newPosition.Y = rnd.Next(3) - 1;
        
            // checking position
            var isXInMatrix = newPosition.X >= 0 && newPosition.X < labyrinth.Field.GetLength(1);
            var isYInMatrix = newPosition.Y >= 0 && newPosition.Y < labyrinth.Field.GetLength(0);

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
