using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Interfaces;
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
        public async Task<IEnumerable<ClientRequest>> SelectClientRequestAll()
        {
            var result = await _context.ClientRequests.AsNoTracking().Where(x => x.Visible).Include(x => x.tour).ToListAsync();
            return result;
        }
    }
}
