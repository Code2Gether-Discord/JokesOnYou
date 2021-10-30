using System;

namespace JokesOnYou.Web.Api.Exceptions
{
    public class InsufficientPermissionsException : Exception
    {
        public InsufficientPermissionsException()
        {
        }

        public InsufficientPermissionsException(string message) : base(message)
        {
        }

        public InsufficientPermissionsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
