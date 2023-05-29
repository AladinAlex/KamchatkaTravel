using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Interfaces
{
    public interface IAdminRepository
    {
        Task CreateQuestion(Question question);
        Task CreateReview(Review question);
    }
}
