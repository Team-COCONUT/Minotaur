namespace Minotaur.Exceptions
{
    using System;

    public class PlayerIsDeadException : ApplicationException
    {
        private const string exceptionMessage = "The player has been slain :(";

        public PlayerIsDeadException()
            : base (exceptionMessage)
        {
        }
    }
}
