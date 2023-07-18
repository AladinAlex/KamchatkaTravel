using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class CreateReviewDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Text { get; set; }
        public byte[]? LogoImage { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now.Date;
    }
}
