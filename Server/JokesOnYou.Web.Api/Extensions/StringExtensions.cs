using System;

namespace JokesOnYou.Web.Api.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToUpperRestToLower(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => string.Concat(input[0].ToString().ToUpper(), input.ToLower().AsSpan(1))
        };
    }
}
