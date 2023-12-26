using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.DataConstants
{
    /// <summary>
    /// Holds Constants for Data Entities.
    /// </summary>
    public static class DataConstants      
    {
        /// <summary>
        /// Holds Constants for Smoothie class.
        /// </summary>
        public class SmoothieConstants
        {
            public const int SmoothieMinLengthName = 3;
            public const int SmoothieMaxLengthName = 100;
        }
        /// <summary>
        /// Holds Constants for ApplicationUser class.
        /// </summary>
        public class ApplicationUserConstants
        {
            public const int ApplicationUserMinLengthName = 2;
            public const int ApplicationUserMaxLengthName = 100;
            public const int ApplicationUserMinLengthEmail = 10;
            public const int ApplicationUserMaxLengthEmail = 50;
            public const int ApplicationUserMinLengthPassword = 5;
            public const int ApplicationUserMaxLengthPassword = 20;
        }
        /// <summary>
        /// Holds Constants for Customer class.
        /// </summary>
        public class CustomerConstants
        {
            public const int CustomerMinLengthName = 2;
            public const int CustomerMaxLengthName = 100;
            public const int CustomerMinLengthEmail = 2;
            public const int CustomerMaxLengthEmail = 100;
            public const int CustomerMinLengthAddress = 2;
            public const int CustomerMaxLengthAddress = 100;
            public const int CustomerMinLengthPhoneNumber = 2;
            public const int CustomerMaxLengthPhoneNumber = 100;
        }
        /// <summary>
        /// Holds Constants for Feedback class.
        /// </summary>
        public class FeedbackConstants
        {
            public const int FeedbackMinLengthRating = 1;
            public const int FeedbackMaxLengthRating = 10;
            public const int FeedbackMinLengthComment = 1;
            public const int FeedbackMaxLengthComment = 10000;
        }
        /// <summary>
        /// Holds Constants for Ingredient class.
        /// </summary>
        public class IngredientConstants
        {
            public const int IngredientMinLengthName = 1;
            public const int IngredientMaxLengthName = 10;
            public const int IngredientMinLengthInfo = 1;
            public const int IngredientMaxLengthInfo = 1000;
        }
        /// <summary>
        /// Holds Constants for Menu class.
        /// </summary>
        public class MenuConstants
        {
            public const int MenutMinLengthName = 1;
            public const int MenuMaxLengthName = 100;        
        }
    }
}
