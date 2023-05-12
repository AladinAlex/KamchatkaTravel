using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Common
{
    public class BaseModel
    {
        public DateTime? UpdateDt { get; set; }
        public DateTime CreateDt { get; set; }
        public bool Visible { get; set; }

    }
}
