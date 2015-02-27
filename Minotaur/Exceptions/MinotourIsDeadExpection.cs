namespace Minotaur.Exceptions
{
    using System;

    public class MinotourIsDeadException : GameOverException
    {
        private const string exceptionMessage = "The minotour has been slain :)";

        public MinotourIsDeadException()
            : base(exceptionMessage)
        {
        }
    }
}
