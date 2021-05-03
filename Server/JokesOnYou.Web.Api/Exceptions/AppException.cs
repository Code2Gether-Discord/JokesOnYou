using System;

namespace JokesOnYou.Web.Api.Exceptions
{
    public class AppException : Exception
    {
        public AppException()
        {
        }

        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}