namespace SmoothieShop.ErrorConstants
{
    /// <summary>
    /// This class holds Error constants messages.
    /// </summary>
   public static class ErrorConstants

   {
        public static class GlobalErrorConstants
        {
            public const string somethingWrong = "Something went wrong, please try again!";
        }

        public static class UserErrorConstants
        {
            public const string invalidLogin = "Invalid Login";
            public const string unAvailableUserName = "This UserName is unavailable. Please try another one";
            public const string unAvailableEmail = "This Email is unavailable. Please try another one";

        }
    }

}
