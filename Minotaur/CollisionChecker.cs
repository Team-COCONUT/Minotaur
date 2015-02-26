namespace Minotaur
{
    using System.Collections.Generic;
    using System.Linq;

    using GameSprites;
    using GameSprites.Mobs;
    using Items;
    using Interfaces;
    
    public static class CollisionChecker
    {
        public static void Check(Player player, ICollection<HealthPotion> potions, ICollection<Mob> mobs, ICollection<Item> items)
        {
            HealthPotion potion = potions.Where(p => p.Position.X == player.Position.X &&
                p.Position.Y == player.Position.Y).FirstOrDefault();

            if (potion != null)
            {
                //add potion to player
                player.ApplyHealthPotionEffect(potion);
                
                //remove potion
                potions.Remove(potion);

                return;
            }

            Mob mob = mobs.Where(m => m.Position.X == player.Position.X &&
                m.Position.Y == player.Position.Y).FirstOrDefault();

            if (mob != null)
            {

            }

            Item item = items.Where(i => i.Position.X == player.Position.X &&
                i.Position.Y == player.Position.Y).FirstOrDefault();

            if (item != null)
            {
                //add item to player's inventory
                player.AddToInventory(item);

                //remove item
                items.Remove(item);

                return;
            }
        }
    }
}
