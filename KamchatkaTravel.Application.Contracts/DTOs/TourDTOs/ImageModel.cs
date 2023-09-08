using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.TourDTOs
{
    public class ImageModel
    {
        public Guid Id { get; set; }
        public byte[] Img { get; set; }
        //public int? Ord { get; set; }
        public IFormFile? ImgFile { get; set; }
        public Guid TourId { get; set; }
        public bool Visible { get; set; }
    }
}
