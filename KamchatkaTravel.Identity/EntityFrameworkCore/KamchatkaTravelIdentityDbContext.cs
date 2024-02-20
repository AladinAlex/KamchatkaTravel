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
        public DbSet<PersonTelegram> PersonTelegrams { get; set; }

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
                q.HasOne(t => t.PersonTelegram).WithOne(t => t.Person).HasForeignKey<PersonTelegram>()
                .IsRequired(false);
            });

            builder.Entity<PersonTelegram>(q => {
                q.ToTable(nameof(PersonTelegram), Schemes.IdentityDbSchema);
                q.HasKey(x => x.Id);
                q.HasIndex(tour => tour.Id).IsUnique(true);
                q.Property(tour => tour.Id).ValueGeneratedOnAdd();
                q.Property(tour => tour.Chat_Id).IsRequired(false);
                q.Property(tour => tour.IsActive).HasDefaultValue(1);
                q.HasOne(t => t.Person).WithOne(t => t.PersonTelegram).HasForeignKey<PersonTelegram>().IsRequired(false);
            });
        }
    }
}
