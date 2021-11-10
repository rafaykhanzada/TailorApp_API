using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorApp_API.Helpers
{
    public static class EnumHelper
    {
        public enum ErrorEnums
        {
            EmptyData = 1,
            NoRecordFound = 2,
            DataAlreadyExist = 3,
            InvalidData = 4,
            Exception = 5
        }
    }
}
