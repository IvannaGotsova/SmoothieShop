using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Data.DataConstants
{
    public  class DataConstants
    {
        public class SmoothieConstants
        {
            public const int SmoothieMinLengthName = 3;
            public const int SmoothieMaxLengthName = 100;
        }

        public class ApplicationUserConstants
        {
            public const int ApplicationUserMinLengthName = 2;
            public const int ApplicationUserMaxLengthName = 100;
        }

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
    }
}
