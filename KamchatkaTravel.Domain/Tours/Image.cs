using KamchatkaTravel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Tours
{
    // блок с картинками 
    public class Image : BaseModel
    {
        public Guid Id { get; set; }
        public byte[] Img { get; set; }
        public int? Ord { get; set; }
    }

}
