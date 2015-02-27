namespace Minotaur
{
    using System.Collections.Generic;
    using System.Linq;
    using Artifacts.Items;
    using Artifacts.Potions;
    using GameSprites;

    public static class CollisionChecker
    {
        public static void CheckPotionCollision(Player player, ICollection<Potion> potions)
        {
            Potion potion = potions.FirstOrDefault(p => p.Position.X == player.Position.X &&
                                            p.Position.Y == player.Position.Y);

            if (potion != null)
            {
                player.ApplyPotionEffect(potion);
                potions.Remove(potion);
            }
        }

        public static void CheckMobCollision(Player player, ICollection<GameSprite> mobs)
        {
            GameSprite mob = mobs.FirstOrDefault(m => m.Position.X == player.Position.X &&
                                                      m.Position.Y == player.Position.Y);

            if (mob != null)
            {
                BattleEngine.StartBattle(player, mob, mobs);
            }
        }

        public static void CheckItemCollision(Player player, ICollection<Item> items)
        {
            Item item = items.FirstOrDefault(i => i.Position.X == player.Position.X &&
                                                  i.Position.Y == player.Position.Y);

            if (item != null)
            {
                player.AddToInventory(item);
                items.Remove(item);
            }
        }
    }
}
