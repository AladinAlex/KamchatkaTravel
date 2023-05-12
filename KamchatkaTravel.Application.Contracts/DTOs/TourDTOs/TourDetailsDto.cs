using KamchatkaTravel.Domain.Shared.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.TourDTOs
{
    public class TourDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public byte[] LogoImage { get; set; }
        public SeasonType SeasonType { get; set; }
        public NightType NightType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] DescriptionImage { get; set; }
        public string LinkEquipment { get; set; }
        public List<ViewDto> Views { get; set; }
        public List<ImageDto> Images { get; set; }
        public List<DayDto> Days { get; set; }
        public List<IncludeDto> Includes { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
