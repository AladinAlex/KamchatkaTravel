using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Shared.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Обрезает текст начиная от startIndex в количестве length символов.
        /// В конце добавляет "..."
        /// </summary>
        /// <param name="str">строка</param>
        /// <param name="startIndex">начальный индекс</param>
        /// <param name="length">количество символов</param>
        /// <returns></returns>
        public static string ToTruncateText(this string str, int? startIndex = 0, int? length = 50)
        { 
            if(string.IsNullOrWhiteSpace(str))
                return "";
            if(str.Length < length)
                return str;
            return str.Substring(startIndex.Value, length.Value) + "...";
        }
    }
}
