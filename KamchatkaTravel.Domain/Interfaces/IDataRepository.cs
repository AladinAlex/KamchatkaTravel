using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Interfaces
{
    public interface IDataRepository
    {
        Task InsertReview(Review review);
        Task InsertTour(Tour tour);
        Task InsertDay(Day day);
        Task InsertImage(Image img);
        Task InsertInclude(Include inc);
        Task InsertQuestion(Question question);
        Task InsertView(View view);
    }
}
