using KamchatkaTravel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Reviews
{
    // блок "отзывы"
    public class Review : BaseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Text { get; set; }
        public byte[] LogoImage { get; set; }
        public DateTime Date { get; set; }
    }
}
