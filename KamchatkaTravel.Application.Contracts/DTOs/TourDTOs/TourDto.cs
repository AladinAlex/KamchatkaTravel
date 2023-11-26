using KamchatkaTravel.Domain.Shared.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.TourDTOs
{
    public class TourDto
    {
        //TODO: то, что отображается на главной странице (карточка тура)
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LogoImageUrl { get; set; }
        public SeasonType SeasonType { get; set; }
        public NightType NightType { get; set; }
        public decimal Price { get; set; }
        //public List<DayDto> Days  { get; set; }
        public int dayCount { get; set; }
    }
}
