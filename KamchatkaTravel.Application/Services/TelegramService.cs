using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Services
{
    public class TelegramService
    {

        private readonly IHttpClientFactory _httpClientFactory = null!;
        public TelegramService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //public 

    }
}
