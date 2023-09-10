using KamchatkaTravel.Identity.Common;
using KamchatkaTravel.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Identity.EntityFrameworkCore
{
    public class KamchatkaTravelIdentityDbContext : IdentityDbContext<IdentityPerson>
    {
        public DbSet<IdentityPerson> Persons { get; set; }
        public KamchatkaTravelIdentityDbContext(DbContextOptions<KamchatkaTravelIdentityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schemes.IdentityDbSchema);

            builder.Entity<IdentityPerson>(q =>
            {
                q.ToTable(nameof(IdentityPerson), Schemes.IdentityDbSchema);
                q.Property(tour => tour.Name).IsRequired().HasColumnType("nvarchar(max)");
                q.Property(tour => tour.Surname).IsRequired(false).HasColumnType("nvarchar(max)");
                q.Property(tour => tour.Comment).IsRequired(false).HasColumnType("nvarchar(max)");
            });
        }

    }
}
