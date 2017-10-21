using System;

namespace Course_API.Exceptions
{
    public class InvalidFacebookTokenException : Exception
    {
        public InvalidFacebookTokenException(string message) : base(message)
        {
        }
    }
}
