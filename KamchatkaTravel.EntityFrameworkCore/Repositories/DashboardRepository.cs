using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Interfaces;
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
    public class DashboardRepository : IDashboardRepository
    {
        readonly KamchatkaTravelDbContext _context;
        public DashboardRepository(KamchatkaTravelDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ClientRequest>> SelectClientRequestAllAsync()
        {
            var result = await _context.ClientRequests.AsNoTracking().Where(x => x.Visible).Include(x => x.tour).ToListAsync();
            return result;
        }

        public async Task UpdateProcessClientRequestAsync(Guid Id)
        {
            var cl = await _context.ClientRequests.Where(x => x.Id == Id).FirstAsync();
            cl.isProcessed = !cl.isProcessed;
            await _context.SaveChangesAsync();
        }

        public async Task<ClientRequest> SelectClientRequestByIdAsync(Guid Id)
        {
            var cl = await _context.ClientRequests.Where(x => x.Id == Id && x.Visible).FirstAsync();
            return cl;
        }

        public async Task UpdateClientRequestByIdAsync(Guid Id, string comment)
        {
            var cl = await _context.ClientRequests.Where(x => x.Id == Id).FirstAsync();

            if (cl.comment != comment)
            {
                cl.comment = comment;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClientRequestByIdAsync(Guid Id)
        {
            var cl = await _context.ClientRequests.Where(x => x.Id == Id).FirstAsync();
            cl.Visible = false;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Tour>> SelectTourAllAsync(bool? isVisible = null)
        {
            var result = _context.Tours.AsNoTracking().Where(x => x.Visible);
            if (isVisible != null)
                result = result.Where(x => x.Visible == isVisible);
            return await result.ToListAsync();
        }
    }
}
