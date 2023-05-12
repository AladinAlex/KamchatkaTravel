using KamchatkaTravel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Tours
{
    // блок включено/невключено в тур
    public class Include : BaseModel
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public bool isInclude { get; set; } // включено/не включено
    }
}
