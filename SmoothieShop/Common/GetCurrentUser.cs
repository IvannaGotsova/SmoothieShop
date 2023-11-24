using System.Security.Claims;

namespace SmoothieShop.Common
{
    public static class GetCurrentUser
    {
        public static string GetCurrentUserId(this ClaimsPrincipal claimsPrincipalUser)
        {
            return claimsPrincipalUser.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        
        public static string GetCurrentUserName(this ClaimsPrincipal claimsPrincipalUser)
        {
            return claimsPrincipalUser.FindFirstValue(ClaimTypes.Name);
        }
    }
}
