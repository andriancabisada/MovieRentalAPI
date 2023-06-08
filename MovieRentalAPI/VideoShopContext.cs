using MovieRentalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        public virtual DbSet<Rentals> Rentals { get; set; } = null!;
        public virtual DbSet<RentalDetails> RentalDetails { get; set; } = null!;
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

            modelBuilder.Entity<Rentals>(entity =>
            {
                entity.ToTable("Rental");
                entity.HasKey(r => r.Id);
                entity.Property(r => r.RentalDate).IsRequired();
                entity.Property(r => r.DueDate).IsRequired();
                entity.HasOne(r => r.Customer)
                    .WithMany(c => c.Rentals)
                    .HasForeignKey(r => r.CustomerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RentalDetails>(entity =>
            {
                entity.ToTable("RentalDetails");
                entity.HasKey(rd => rd.Id);
                entity.Property(rd => rd.Quantity).IsRequired();
                entity.HasOne(rd => rd.Rental)
                    .WithMany()
                    .HasForeignKey(rd => rd.RentalId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(rd => rd.Movie)
                    .WithMany()
                    .HasForeignKey(rd => rd.MovieId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });
            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

