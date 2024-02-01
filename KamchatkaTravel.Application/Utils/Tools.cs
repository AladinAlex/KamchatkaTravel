using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Utils
{
    public static class Tools
    {
        public static IList<string> GetPictures()
        {
            IList<string> result = new List<string>();

            var path = Directory.GetCurrentDirectory() + "/wwwroot/images/MainPicturesSeparate";
            foreach (var file in Directory.GetFiles(path, "*kamchatka*"))
            {
                result.Add(Path.GetFileName(file));
            }

            return result;
        }
    }
}
