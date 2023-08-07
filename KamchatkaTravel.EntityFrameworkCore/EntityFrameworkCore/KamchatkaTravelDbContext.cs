using KamchatkaTravel.Domain;
using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Common;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Shared.Tours;
using KamchatkaTravel.Domain.Tours;
using Microsoft.EntityFrameworkCore;

namespace KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore
{
    public class KamchatkaTravelDbContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Image> Images{ get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<Include> Includes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<ClientRequest> ClientRequests { get; set; }

        public KamchatkaTravelDbContext(DbContextOptions<KamchatkaTravelDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Modified)
                    ((BaseModel)entityEntry.Entity).UpdateDt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    ((BaseModel)entityEntry.Entity).CreateDt = DateTime.Now;
            }
            try
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //_ = 2;
                return default;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tour>(q =>
            {
                q.ToTable(nameof(Tour), TourConsts.DbSchema);
                q.HasKey(x => x.Id);
                q.HasIndex(tour => tour.Id).IsUnique(true);
                q.Property(tour => tour.Id).HasDefaultValueSql("newid()");
                q.Property(tour => tour.Name).IsRequired().HasColumnType("nvarchar(64)");
                q.Property(tour => tour.Tagline).IsRequired().HasColumnType("nvarchar(128)");
                q.Property(tour => tour.LogoImage).IsRequired().HasColumnType("varbinary(max)");
                q.Property(tour => tour.SeasonType).IsRequired().HasDefaultValue(SeasonType.All);
                q.Property(tour =>tour.NightType).IsRequired().HasDefaultValue(NightType.defaultValue);
                q.Property(tour => tour.Price).IsRequired().HasColumnType("decimal(16, 2)");
                q.Property(tour => tour.Description).IsRequired().HasColumnType("nvarchar(max)");
                q.Property(tour => tour.DescriptionImage).IsRequired().HasColumnType("varbinary(max)");
                q.Property(tour => tour.Visible).HasDefaultValue(1);
                q.Property(tour => tour.LinkEquipment).IsRequired(false);
                q.Property(tour => tour.CreateDt).IsRequired().HasColumnType("datetime2");
                q.Property(tour => tour.UpdateDt).HasColumnType("datetime2");
            });

            builder.Entity<Day>(d =>
            {
                d.ToTable(nameof(Day), TourConsts.DbSchema);
                d.HasKey(d => d.Id);
                d.HasIndex(d => d.Id).IsUnique(true);
                d.Property(d => d.Id).HasDefaultValueSql("newid()");
                d.Property(d => d.Name).IsRequired().HasColumnType("nvarchar(64)");
                d.Property(d => d.Number).IsRequired().HasColumnType("nvarchar(64)");
                d.Property(d => d.Description).IsRequired().HasColumnType("nvarchar(max)");
                d.Property(d => d.Image).IsRequired().HasColumnType("varbinary(max)");
                //d.Property(d => d.Tour).IsRequired();
                d.Property(d => d.Visible).HasDefaultValue(true);
                d.Property(d => d.CreateDt).IsRequired().HasColumnType("datetime2");
                d.Property(d => d.UpdateDt).HasColumnType("datetime2");
            });

            builder.Entity<Image>(d =>
            {
                d.ToTable(nameof(Image), TourConsts.DbSchema);
                d.HasKey(d => d.Id);
                d.HasIndex(d => d.Id).IsUnique(true);
                d.Property(d => d.Id).HasDefaultValueSql("newid()");
                d.Property(d => d.Img).IsRequired().HasColumnType("varbinary(max)");
                //d.Property(d => d.Tour).IsRequired();
                d.Property(d => d.Visible).HasDefaultValue(true);
                d.Property(d => d.Ord).IsRequired(false);
                d.Property(d => d.CreateDt).IsRequired().HasColumnType("datetime2");
                d.Property(d => d.UpdateDt).HasColumnType("datetime2");
            });

            builder.Entity<Include>(d =>
            {
                d.ToTable(nameof(Include), TourConsts.DbSchema);
                d.HasKey(d => d.Id);
                d.HasIndex(d => d.Id).IsUnique(true);
                d.Property(d => d.Number).IsRequired();
                d.Property(d => d.Id).HasDefaultValueSql("newid()");
                d.Property(d => d.Text).IsRequired().HasColumnType("nvarchar(256)");
                d.Property(d => d.Visible).HasDefaultValue(true);
                //d.Property(d => d.Tour).IsRequired();
                d.Property(d => d.isInclude).IsRequired();
                d.Property(d => d.CreateDt).IsRequired().HasColumnType("datetime2");
                d.Property(d => d.UpdateDt).HasColumnType("datetime2");
            });

            builder.Entity<Question>(q => {
                q.ToTable(nameof(Question), TourConsts.DbSchema);
                q.HasKey(q => q.Id);
                q.HasIndex(q => q.Id).IsUnique(true);
                q.Property(q => q.Id).HasDefaultValueSql("newid()");
                q.Property(q => q.Name).IsRequired().HasColumnType("nvarchar(512)");
                q.Property(q => q.Answer).IsRequired().HasColumnType("nvarchar(512)");
                q.Property(q => q.Visible).HasDefaultValue(true);
                q.Property(q => q.Ord).IsRequired(false);
                q.Property(q => q.CreateDt).IsRequired().HasColumnType("datetime2");
                q.Property(q => q.UpdateDt).HasColumnType("datetime2");
            });

            builder.Entity<View>(v => {
                v.ToTable(nameof(View), TourConsts.DbSchema);
                v.HasKey(v => v.Id);
                v.HasIndex(v => v.Id).IsUnique(true);
                v.Property(v => v.Id).HasDefaultValueSql("newid()");
                v.Property(v => v.Name).IsRequired().HasColumnType("nvarchar(128)");
                v.Property(v => v.Description).IsRequired().HasColumnType("nvarchar(max)");
                v.Property(v => v.Image).IsRequired().HasColumnType("varbinary(max)");
                v.Property(v => v.Visible).HasDefaultValue(true);
                v.Property(v => v.CreateDt).IsRequired().HasColumnType("datetime2");
                v.Property(v => v.UpdateDt).HasColumnType("datetime2");
            });

            builder.Entity<Review>(r => {
                r.ToTable(nameof(Review), TourConsts.DbSchema);
                r.HasKey(r => r.Id);
                r.HasIndex(r => r.Id).IsUnique(true);
                r.Property(r => r.Id).HasDefaultValueSql("newid()");
                r.Property(r => r.FirstName).IsRequired().HasColumnType("nvarchar(64)");
                r.Property(r => r.LastName).IsRequired(false).HasColumnType("nvarchar(64)");
                r.Property(r => r.Text).IsRequired().HasColumnType("nvarchar(max)");
                r.Property(r => r.LogoImage).IsRequired(false).HasColumnType("varbinary(max)");
                r.Property(r => r.Visible).HasDefaultValue(true);
                r.Property(r => r.CreateDt).IsRequired().HasColumnType("datetime2");
                r.Property(r => r.UpdateDt).HasColumnType("datetime2");
            });

            builder.Entity<ClientRequest>(cl =>
            {
                cl.ToTable(nameof(ClientRequest), TourConsts.DbSchema);
                cl.HasKey(cl => cl.Id);
                cl.HasIndex(cl => cl.Id).IsUnique(true);
                cl.Property(cl => cl.Id).HasDefaultValueSql("newid()");
                cl.Property(cl => cl.FirstName).IsRequired().HasColumnType("nvarchar(64)");
                cl.Property(cl => cl.Email).IsRequired().HasColumnType("nvarchar(64)");
                cl.Property(cl => cl.Phone).IsRequired().HasColumnType("nvarchar(32)");
                cl.Property(cl => cl.Visible).HasDefaultValue(true);
                cl.Property(cl => cl.isProcessed).IsRequired().HasDefaultValue(true);
                cl.Property(cl => cl.TourId).IsRequired(false);
                cl.Property(cl => cl.CreateDt).IsRequired().HasColumnType("datetime2");
                cl.Property(cl => cl.UpdateDt).HasColumnType("datetime2");
            });
        }

    }
}
