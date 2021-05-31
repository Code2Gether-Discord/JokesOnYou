using System.Security.Claims;

namespace JokesOnYou.Web.Api.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
