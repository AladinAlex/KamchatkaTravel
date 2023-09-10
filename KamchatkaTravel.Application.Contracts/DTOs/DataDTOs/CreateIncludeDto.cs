using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class CreateIncludeDto
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public bool isInclude { get; set; }
        public Guid? TourId { get; set; }

    }
}
