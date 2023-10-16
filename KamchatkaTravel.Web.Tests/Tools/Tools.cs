using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Web.Tests.Tools
{
    public static class Tools
    {
        public static string RandomText(int length)
        {
            const string LoremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            return String.Join(Environment.NewLine, Array.ConvertAll(new int[length], i => LoremIpsum));
        }
        public static int RandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int number = rnd.Next(min, max+1);
            return number;
        }
    }
}
