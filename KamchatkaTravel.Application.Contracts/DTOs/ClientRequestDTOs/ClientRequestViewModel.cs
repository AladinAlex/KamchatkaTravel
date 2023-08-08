using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs
{
    public class ClientRequestViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isProcessed { get; set; }
        public Guid? TourId { get; set; }
        public string? comment { get; set; }
        public string? tourName { get; set; }
    }
}
