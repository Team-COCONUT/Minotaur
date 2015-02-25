namespace Minotaur.Interfaces
{
    using Enumerations;

    public interface IMovable
    {
        void Move(Directions direction, Labyrinth labyrinth);
    }
}
