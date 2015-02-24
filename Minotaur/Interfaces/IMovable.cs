namespace Minotaur.Interfaces
{
    using Minotaur.Enumerations;

    public interface IMovable
    {
        void Move(Directions direction, Labyrinth labyrinth);
    }
}
