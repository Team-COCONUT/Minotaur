namespace Minotaur
{
    using System.Collections.Generic;
    using System.Linq;

    using GameSprites;
    using GameSprites.Mobs;
    using Items;
    
    public static class CollisionChecker
    {
        public static void Check(Player player, ICollection<HealthPotion> potions, ICollection<Mob> mobs)
        {
            var potion = potions.Where(p => p.Position.X == player.Position.X &&
                p.Position.Y == player.Position.Y).FirstOrDefault();

            if (potion != null)
            {
                //add potion to player
                player.ApplyHealthPotionEffect(potion); //or something like that
                
                //remove potion
                potions.Remove(potion);
                return;
            }

            var mob = mobs.Where(m => m.Position.X == player.Position.X &&
                m.Position.Y == player.Position.Y).FirstOrDefault();

            if (mob != null)
            {
                //Start battle
            }
        }
    }
}
