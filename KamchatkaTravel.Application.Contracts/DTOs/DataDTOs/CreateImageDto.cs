using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class CreateImageDto
    {
        public byte[] Img { get; set; }
        public int? Ord { get; set; }
    }
}
