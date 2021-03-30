using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Exceptions
{
    public class UserRegisterException : Exception
    {
        public UserRegisterException()
        {
        }

        public UserRegisterException(string message) : base(message)
        {
        }

        public UserRegisterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
