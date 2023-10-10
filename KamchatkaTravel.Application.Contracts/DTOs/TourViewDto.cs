using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs
{
    public class TourViewDto
    {
        public TourDetailsDto Tour { get; set; }
        //public IList<ViewDto> Views { get; set; }
        //public IList<ImageDto> Images { get; set; }
        //public IList<DayDto> Days { get; set; }
        //public IList<IncludeDto> Includes { get; set; }
        //public IList<QuestionDto> Questions { get; set; }
        public IList<string> PicturesLink
        {
            get
            {
                //return System.IO.Directory.GetCurrentDirectory();
                //return Environment.CurrentDirectory;
                IList<string> result = new List<string>();

                var path = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/images/MainPicturesSeparate";
                foreach (var file in Directory.GetFiles(path, "*kamchatka*"))
                {
                    result.Add(System.IO.Path.GetFileName(file));
                }

                return result;
            }
        }
    }
}
