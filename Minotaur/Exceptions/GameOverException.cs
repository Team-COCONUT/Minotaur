namespace Minotaur.Exceptions
{
    using System;

    public class GameOverException : ApplicationException
    {
        public GameOverException(string exceptionMessage)
            : base(exceptionMessage)
        {
        }
    }
}
