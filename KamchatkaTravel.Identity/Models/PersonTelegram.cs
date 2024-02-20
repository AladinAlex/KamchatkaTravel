using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Identity.Models
{
    public class PersonTelegram
    {
        public int Id { get; set; }
        public int? Chat_Id { get; set; }
        public bool IsActive { get; set; }
        public IdentityPerson? Person { get; set; }
    }
}
