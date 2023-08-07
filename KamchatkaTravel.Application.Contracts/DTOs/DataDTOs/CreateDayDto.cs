using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class CreateDayDto
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public IFormFile? Img { get; set; }
        public Guid tourID { get; set; }
    }
}
