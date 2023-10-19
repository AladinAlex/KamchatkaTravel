using KamchatkaTravel.Domain.Common;
using KamchatkaTravel.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.ClientRequests
{
    public class ClientRequest : BaseModel
    {
        public Guid Id { get; set; }
        //public Guid UserId { get; set; } // identityServer 4. От туда UserId
        public string FirstName { get; set; }   
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isProcessed { get; set; }
        public Guid? TourId { get; set; }
        public Tour? tour { get; set; }
        public string? comment { get; set; }
    }
}
