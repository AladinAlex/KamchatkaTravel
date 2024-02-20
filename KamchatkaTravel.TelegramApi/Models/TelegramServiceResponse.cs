using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.TelegramApi.Models
{
    public class TelegramServiceResponse
    {
        public bool Success { get; set; } = true!;
        public object Data { get; set; }
        public string Error { get; set; }
    }
}
