using KamchatkaTravel.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Tours
{
    // блок "Частые вопросы"
    public class Question : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }
        public int? Ord { get; set; }
    }
}
