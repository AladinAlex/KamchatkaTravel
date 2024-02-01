using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Shared.Utils
{
    public static class Tools
    {
        private static Dictionary<char, string> map = new Dictionary<char, string>
            {
                { 'а', "a" },
                { 'б', "b" },
                { 'в', "v" },
                { 'г', "g" },
                { 'д', "d" },
                { 'е', "e" },
                { 'ё', "yo" },
                { 'ж', "zh" },
                { 'з', "z" },
                { 'и', "i" },
                { 'й', "y" },
                { 'к', "k" },
                { 'л', "l" },
                { 'м', "m" },
                { 'н', "n" },
                { 'о', "o" },
                { 'п', "p" },
                { 'р', "r" },
                { 'с', "s" },
                { 'т', "t" },
                { 'у', "u" },
                { 'ф', "f" },
                { 'х', "kh" },
                { 'ц', "ts" },
                { 'ч', "ch" },
                { 'ш', "sh" },
                { 'щ', "sch" },
                { 'ъ', "" },
                { 'ы', "y" },
                { 'ь', "" },
                { 'э', "e" },
                { 'ю', "yu" },
                { 'я', "ya" },
            };

        public static string GetRouteByName(string name)
        {
            return Translit(name);
        }

        private static string Translit(string str)
        {
            str = str.ToLower().Replace(" ", string.Empty);
            return string.Concat(str.Select(c =>
            {
                try
                {
                    return map[c];
                }
                catch
                {
                    return c.ToString();
                }
            }));
        }
    }
}
