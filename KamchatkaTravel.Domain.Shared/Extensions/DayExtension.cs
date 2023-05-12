using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace KamchatkaTravel.Domain.Shared.Extensions
{
    public static class DayExtension
    {
        public static string AddWordDay(this int value)
        {
            string result = value.ToString();
            if (value % 10 == 1)
                result += " день";
            if(Enumerable.Range(2, 4).Contains(value % 10))
                result += " дня";
            if (Enumerable.Range(5, 9).Contains(value % 10) || value % 10 == 0 || Enumerable.Range(11, 14).Contains(value % 100))
                result += " дней";
            return result;
        }
    }
}
