using MovieRentalAPI.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

public class VideoShopContext : DbContext
{
    public Microsoft.EntityFrameworkCore.DbSet<Movie> Movies { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Customer> Customers { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Rental> Rentals { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<RentalDetail> RentalDetails { get; set; }

    public VideoShopContext(DbContextOptions<VideoShopContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Movie entity
        modelBuilder.Entity<Movie>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<Movie>()
            .Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Movie>()
            .Property(m => m.Genre)
            .IsRequired()
            .HasMaxLength(50);

        // Configure Customer entity
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Email)
            .HasMaxLength(100);

        // Configure Rental entity
        modelBuilder.Entity<Rental>()
            .HasKey(r => r.Id);

  


        // Configure RentalDetail entity
        modelBuilder.Entity<RentalDetail>()
            .HasKey(rd => rd.Id);

        

        base.OnModelCreating(modelBuilder);

    }
}
