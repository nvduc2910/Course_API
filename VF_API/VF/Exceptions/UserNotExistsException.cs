using System;

namespace Course_API.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException(string message) : base(message) { }
    }
}
