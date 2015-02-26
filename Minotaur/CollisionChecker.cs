namespace Minotaur
{
    using System.Collections.Generic;
    using System.Linq;

    using GameSprites;
    using GameSprites.Mobs;
    using GameSprites.Potions;
    using Items;

    public static class CollisionChecker
    {
        public static void CheckPotionCollision(Player player, ICollection<Potion> potions)
        {
            var potion = potions.FirstOrDefault(p => p.Position.X == player.Position.X &&
                                            p.Position.Y == player.Position.Y);

            if (potion != null)
            {
                //add potion to player
                player.ApplyPotionEffect(potion);

                //remove potion
                potions.Remove(potion);
            }
        }

        public static void CheckMobCollision(Player player, ICollection<Mob> mobs)
        {
            var mob = mobs.FirstOrDefault(m => m.Position.X == player.Position.X &&
                                               m.Position.Y == player.Position.Y);

            if (mob != null)
            {
                player.Attack(mob);
                mob.Attack(player);
                if (mob.HealthPoints <= 0)
                {
                    mobs.Remove(mob);
                }
            }
        }

        public static void CheckItemCollision(Player player, ICollection<Item> items)
        {
            var item = items.FirstOrDefault(i => i.Position.X == player.Position.X &&
                                                  i.Position.Y == player.Position.Y);

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
