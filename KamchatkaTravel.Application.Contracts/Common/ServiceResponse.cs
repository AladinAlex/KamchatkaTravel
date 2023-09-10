using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.Common
{
    public class ServiceResponse
    {
        public string ResponseId { get; set; }
        public string? Error { get; set; }
        public ResponseCode ResponseCode { get; set; }

        public ServiceResponse()
        { 
            this.ResponseId = Guid.NewGuid().ToString();
            this.ResponseCode = ResponseCode.Ok;
        }
        public ServiceResponse(ResponseCode ResponseCode)
        {
            this.ResponseId = Guid.NewGuid().ToString();
            this.ResponseCode = ResponseCode;
        }
        public ServiceResponse(ResponseCode ResponseCode, string Error)
        {
            this.ResponseId = Guid.NewGuid().ToString();
            this.ResponseCode = ResponseCode;
            this.Error = Error;
        }
    }
}
