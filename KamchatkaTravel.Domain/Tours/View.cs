using KamchatkaTravel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Tours
{
    // блок "что увидим?"
    public class View : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Tour tour { get; set; }
        public Nullable<Guid> TourId { get; set; }
    }
}
