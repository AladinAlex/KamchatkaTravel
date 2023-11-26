using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.TourDTOs
{
    public class DayDto
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid TourId { get; set; }
    }
}
