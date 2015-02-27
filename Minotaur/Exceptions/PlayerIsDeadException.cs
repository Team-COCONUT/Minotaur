namespace Minotaur.Exceptions
{
    using System;

    public class PlayerIsDeadException : GameOverException
    {
        private const string exceptionMessage = "The player has been slain :(";

        public PlayerIsDeadException()
            : base (exceptionMessage)
        {
        }
    }
}
