namespace Minotaur.Interfaces
{
    using Artifacts.Potions;

    interface IDrinkable
    {
        void ApplyPotionEffect(Potion potion);
    }
}
