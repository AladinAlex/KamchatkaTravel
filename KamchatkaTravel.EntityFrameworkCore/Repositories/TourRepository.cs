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
            var questions = await _context.Questions.Where(t => t.Visible == true && t.TourId == null).OrderBy(t => t.Name).ToListAsync();
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
                //.Include(x => x.Days.Where(u => u.Visible))
                //.Include(x => x.Includes.Where(u => u.Visible))
                //.Include(x => x.Questions.Where(u => u.Visible))
                //.Include(x => x.Images.Where(u => u.Visible))
                //.Include(x => x.Views.Where(u => u.Visible))
                .Where(t => t.Visible && t.Id == id)
                .FirstAsync();

            tour.Days = await _context.Days.Where(t => t.Visible && t.TourId == id).ToListAsync();

            tour.Includes = await _context.Includes.Where(t => t.Visible && t.TourId == id).ToListAsync();

            tour.Questions = await _context.Questions.Where(t => t.Visible && t.TourId == id).ToListAsync();

            tour.Images = await _context.Images.Where(t => t.Visible && t.TourId == id).ToListAsync();

            tour.Views = await _context.Views.Where(t => t.Visible && t.TourId == id).ToListAsync();

            return tour;
        }

        public async Task<Tour> GetTourByRouteNameAsync(string TourName)
        {

            var tour = await _context.Tours
                .Where(t => t.Visible && t.RouteName == TourName)
                .Include(x => x.Days.Where(u => u.Visible))
                .Include(x => x.Includes.Where(u => u.Visible))
                .Include(x => x.Questions.Where(u => u.Visible))
                .Include(x => x.Images.Where(u => u.Visible))
                .Include(x => x.Views.Where(u => u.Visible))
                .AsSplitQuery()
                .FirstAsync();

            return tour;
        }
    }
}
