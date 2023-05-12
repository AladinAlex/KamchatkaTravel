using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;

namespace KamchatkaTravel.Application.Contracts.DTOs
{
    public class IndexDto
    {
        public IEnumerable<TourDto> Tours { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }
        public IList<string> PicturesLink
        {
            get
            {
                IList<string> result = new List<string>();

                var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\MainPicturesSeparate";
                foreach (var file in Directory.GetFiles(path, "*kamchatka*"))
                {
                    result.Add(Path.GetFileName(file));
                }

                return result;
            }
        }
    }
}
