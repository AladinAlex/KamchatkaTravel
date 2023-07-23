using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.EntityFrameworkCore.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly KamchatkaTravelDbContext _context;

        public DataRepository(KamchatkaTravelDbContext context)
        {
            _context = context;
        }

        public async Task InsertQuestion(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task InsertReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
        public async Task InsertTour(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
        }
        public async Task InsertDay(Day day)
        {
            await _context.Days.AddAsync(day);
            await _context.SaveChangesAsync();
        }

        public async Task InsertImage(Image img)
        {
            await _context.Images.AddAsync(img);
            await _context.SaveChangesAsync();
        }

        public async Task InsertInclude(Include inc)
        {
            await _context.Includes.AddAsync(inc);
            await _context.SaveChangesAsync();
        }

        public async Task InsertView(View view)
        {
            await _context.Views.AddAsync(view);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tour>> SelectTours()
        {
            var tours = await _context.Tours.Where(t => t.Visible).Select(x => new Tour { Id = x.Id, Name = x.Name }).ToListAsync();
            return tours;
        }
    }
}
