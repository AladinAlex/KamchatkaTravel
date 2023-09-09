using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.TourDTOs
{
    public class DayModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public Guid TourId { get; set; }
        public bool Visible { get; set; }

    }
}
