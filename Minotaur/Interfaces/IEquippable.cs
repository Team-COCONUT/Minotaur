namespace Minotaur.Interfaces
{
    public interface IEquippable
    {
        // TODO: implement equip and unequip methods in items
        // void Equip();
        // void Unequip();

        int DefenseEffect { get; }
        int AttackEffect { get; }
        int SpeedEffect { get; }
    }
}
