using ITLA_TV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITLA_TV.Infraestructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> db) : base(db) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Gender> Genres { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Serie>())
            {
                if (entry.Entity.PrimaryGenderId == entry.Entity.SecondaryGenderId)
                {
                    entry.Entity.SecondaryGenderId = null;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Producer>().ToTable("Productoras");
            modelBuilder.Entity<Gender>().ToTable("Generos");

            #endregion

            #region Primary Keys
            modelBuilder.Entity<Serie>().HasKey(s => s.Id);
            modelBuilder.Entity<Producer>().HasKey(p => p.Id);
            modelBuilder.Entity<Gender>().HasKey(g => g.Id);

            #endregion

            #region Foreign Keys

            #region Series producer
            modelBuilder.Entity<Producer>()
                .HasMany<Serie>(producer => producer.series)
                .WithOne(s => s.Producer)
                .HasForeignKey(s => s.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Genres

            modelBuilder.Entity<Gender>()
                .HasMany(x => x.seriesPrimary)
                .WithOne(s => s.PrimaryGender)
                .HasForeignKey(s => s.PrimaryGenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gender>()
                .HasMany(x => x.seriesSecondary)
                .WithOne(s => s.SecondaryGender)
                .HasForeignKey(s => s.SecondaryGenderId)
                .OnDelete(DeleteBehavior.Restrict);
                



            #endregion

            #endregion

            #region Properties config

            #region Series
            modelBuilder.Entity<Serie>(config =>
            {
                config.Property(e => e.Id).ValueGeneratedOnAdd();
                config.Property(e => e.Name).IsRequired();
                config.Property(e => e.ImagePath).IsRequired();
                config.Property(e => e.VideoPath).IsRequired();
                config.Property(e => e.ProducerId).IsRequired();
            });
            #endregion

            #region Producers and Genres

            modelBuilder.Entity<Producer>(config =>
            {
                config.Property(e => e.Name).IsRequired();
                config.HasIndex(e => e.Name).IsUnique();
            });




            modelBuilder.Entity<Gender>(config =>
            {
                config.Property(e => e.Name).IsRequired();
                config.HasIndex(e => e.Name).IsUnique();
            });

            #endregion

            #endregion
        }
    }
}
