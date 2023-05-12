using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Shared.Extensions
{
    public static class LastNameExtension
    {
        public static string FirstChar(this string value)
        {
            return value.Substring(0, 1);
        }
    }
}
