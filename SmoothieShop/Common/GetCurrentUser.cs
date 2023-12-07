using System.Security.Claims;

namespace SmoothieShop.Common
{
    /// <summary>
    /// This class returns information about current(login) user.
    /// </summary>
    public static class GetCurrentUser
    {
        /// <summary>
        /// This method returns current user Id.
        /// </summary>
        /// <param name="claimsPrincipalUser"></param>
        public static string GetCurrentUserId(this ClaimsPrincipal claimsPrincipalUser)
        {
            return claimsPrincipalUser.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        /// <summary>
        /// This method returns current user Name.
        /// </summary>
        /// <param name="claimsPrincipalUser"></param>
        public static string GetCurrentUserName(this ClaimsPrincipal claimsPrincipalUser)
        {
            return claimsPrincipalUser.FindFirstValue(ClaimTypes.Name);
        }
    }
}
