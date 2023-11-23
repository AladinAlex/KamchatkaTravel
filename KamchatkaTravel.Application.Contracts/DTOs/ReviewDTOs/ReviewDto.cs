using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs
{
    public class ReviewDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Text { get; set; }
        //public byte[] LogoImage { get; set; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string LogoImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
