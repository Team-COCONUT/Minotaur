namespace Minotaur.Interfaces
{
    using Artifacts.Items;

    public interface IEquippable
    {
        void AddToInventory(Item item);
        void RemoveFromInventory(Item item);
        void ApplyItemEffects(Item item);
        void RemoveItemEffects(Item item);
    }
}
