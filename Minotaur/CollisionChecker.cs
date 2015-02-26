namespace Minotaur
{
    using System.Collections.Generic;
    using System.Linq;

    using GameSprites;
    using GameSprites.Mobs;
    using GameSprites.Potions;
    using Items;
    using Interfaces;
    
    public static class CollisionChecker
    {
        public static void Check(Player player, ICollection<Potion> potions, ICollection<GameSprite> mobs, ICollection<Item> items)
        {
            Potion potion = potions.Where(p => p.Position.X == player.Position.X &&
                p.Position.Y == player.Position.Y).FirstOrDefault();

            if (potion != null)
            {
                //add potion to player
                player.ApplyPotionEffect(potion);
                
                //remove potion
                potions.Remove(potion);

                return;
            }

            GameSprite mob = mobs.Where(m => m.Position.X == player.Position.X &&
                m.Position.Y == player.Position.Y).FirstOrDefault();

            if (mob != null)
            {
                string battleResult = BattleEngine.StartBattle(player, mob, mobs);
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
