using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.TourDTOs
{
    public class IncludeModel
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public bool isInclude { get; set; } // включено/не включено
        public Guid TourId { get; set; }
        public bool Visible { get; set; }
    }
}
