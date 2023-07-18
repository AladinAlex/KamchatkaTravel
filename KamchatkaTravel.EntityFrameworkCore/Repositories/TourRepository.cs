using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.EntityFrameworkCore.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly KamchatkaTravelDbContext _context;
        public TourRepository(KamchatkaTravelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tour>> GetToursAsync()
        {
            var tours = await _context.Tours
                .Include(d => d.Days)
                .Where(t => t.Visible == true).OrderBy(t => t.Name).ToListAsync();
            return tours;
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            var questions = await _context.Questions.Where(t => t.Visible == true).OrderBy(t => t.Name).ToListAsync();
            return questions;
        }

        public async Task CreateClientRequest(string FirstName, string Email, string Phone, Guid? TourId)
        {
            await _context.ClientRequests.AddAsync(new ClientRequest()
            {
                FirstName = FirstName,
                Email = Email,
                Phone = Phone,
                TourId = TourId
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetTop5ReviewsAsync()
        {
            var reviews = await _context.Reviews
                .Where(r => r.Visible)
                .OrderByDescending(r => r.Date)
                .Take(5)
                .ToListAsync();
            return reviews;
        }

        public async Task<Tour> GetTourByIdAsync(Guid id)
        {
            // 1:14
            //Stopwatch st = new Stopwatch();
            //st.Start();
            //var tour = await _context.Tours
            //    .Include(t => t.Days)
            //    .Include(t => t.Includes)
            //    .Include(t => t.Questions)
            //    .Include(t => t.Images)
            //    .Include(t => t.Views)
            //    .Where(t => t.Visible && t.Id == id)
            //    .FirstOrDefaultAsync();
            //st.Stop();

            var tour = await _context.Tours
                .Where(t => t.Visible && t.Id == id)
                .FirstOrDefaultAsync();

            tour.Days = await _context.Tours.Where(t => t.Visible && t.Id == id)
                .Select(t => t.Days).FirstOrDefaultAsync();

            tour.Includes = await _context.Tours.Where(t => t.Visible && t.Id == id)
                .Select(t => t.Includes).FirstOrDefaultAsync();

            tour.Questions = await _context.Tours.Where(t => t.Visible && t.Id == id)
                .Select(t => t.Questions).FirstOrDefaultAsync();

            tour.Images = await _context.Tours.Where(t => t.Visible && t.Id == id)
                .Select(t => t.Images).FirstOrDefaultAsync();

            tour.Views = await _context.Tours.Where(t => t.Visible && t.Id == id)
                .Select(t => t.Views).FirstOrDefaultAsync();

            return tour;
        }
    }
}
