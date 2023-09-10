using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Identity.Models
{
    public class IdentityResponse
    {
        public string ResponseId { get; set; }
        public ResponseStatus Status { get; set; }
        public string? Error { get; set; }
        public IdentityResponse() => this.ResponseId = Guid.NewGuid().ToString();
        public IdentityResponse(ResponseStatus status)
        {
            this.ResponseId = Guid.NewGuid().ToString();
            this.Status = status;
        }
        public IdentityResponse(ResponseStatus status, string error)
        {
            this.ResponseId = Guid.NewGuid().ToString();
            this.Status = status;
            if(status != ResponseStatus.Success)
                this.Error = error;
        }
    }
}
