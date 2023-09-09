using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.TourDTOs
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }
        public int? Ord { get; set; }
        public Guid? TourId { get; set; }
        public bool Visible { get; set; }
    }
}
