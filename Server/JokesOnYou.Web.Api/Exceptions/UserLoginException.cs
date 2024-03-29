﻿using System;

namespace JokesOnYou.Web.Api.Exceptions
{
    public class UserLoginException : Exception
    {
        public UserLoginException()
        {
        }

        public UserLoginException(string message) : base(message)
        {
        }

        public UserLoginException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
