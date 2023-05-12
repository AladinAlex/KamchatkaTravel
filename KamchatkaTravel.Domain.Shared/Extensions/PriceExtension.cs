using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Shared.Extensions
{
    public static class PriceExtension
    {
        public static string ToNiceStringFormat(this decimal value)
        {
            return value.ToString("N0");
        }
    }
}
