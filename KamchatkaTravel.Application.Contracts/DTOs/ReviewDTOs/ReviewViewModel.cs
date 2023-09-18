using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Text { get; set; }
        public byte[] LogoImage { get; set; }
        public DateTime Date { get; set; }
        public bool Visible { get; set; }
    }
}
