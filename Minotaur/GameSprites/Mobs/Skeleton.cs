using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotaur.GameSprites.Mobs
{
    public abstract class Skeleton : Mob
    {
        private const int Health = 100;
        private const int Attack = 20;
        private const int Defense = 50;
        private const int MobSpeed = 0;

        public Skeleton(Coords position, int healthPoints = Health, int attackPoints = Attack, 
            int defensePoints = Defense, int mobSpeed = MobSpeed)
            : base(position, healthPoints, attackPoints, defensePoints, mobSpeed)
        {
        }
    }
}
