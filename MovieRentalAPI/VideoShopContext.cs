using MovieRentalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRentalAPI
{
    public partial class VideoShopContext : DbContext
    {

        public VideoShopContext()
        {
        }
        public VideoShopContext(DbContextOptions<VideoShopContext> options) : base(options)
        {

        }
        public virtual DbSet<Movies> Movies { get; set; } = null!;
        public virtual DbSet<Customers> Customers { get; set; } = null!;
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<RentalDetail> RentalDetails { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.ToTable("Movie");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.Property(m => m.Genre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("Customer");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Email)
                .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

