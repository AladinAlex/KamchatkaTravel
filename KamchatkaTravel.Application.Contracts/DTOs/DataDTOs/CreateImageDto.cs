using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class CreateImageDto
    {
        public IFormFile Image { get; set; }
        public int? Ord { get; set; }
        public Guid TourId { get; set; }
    }
}
