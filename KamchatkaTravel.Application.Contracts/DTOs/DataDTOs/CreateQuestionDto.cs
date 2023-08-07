using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class CreateQuestionDto
    {
        public string Name { get; set; }
        public string Answer { get; set; }
        public int? Ord { get; set; }
        public Guid? TourId { get; set; }
    }
}
