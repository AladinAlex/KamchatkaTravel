using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.EntityFrameworkCore.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly KamchatkaTravelDbContext _context;

        public AdminRepository(KamchatkaTravelDbContext context)
        {
            _context = context;
        }

        public async Task CreateQuestion(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task CreateReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
    }
}
