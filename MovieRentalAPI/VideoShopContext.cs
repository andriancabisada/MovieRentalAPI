using MovieRentalAPI.Models;
using System.Data.Entity;

public class VideoShopContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalDetail> RentalDetails { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
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

        modelBuilder.Entity<Rental>()
            .HasRequired(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerId)
            .WillCascadeOnDelete(false);


        // Configure RentalDetail entity
        modelBuilder.Entity<RentalDetail>()
            .HasKey(rd => rd.Id);

        modelBuilder.Entity<RentalDetail>()
            .HasRequired(rd => rd.Movie)
            .WithMany()
            .HasForeignKey(rd => rd.MovieId)
            .WillCascadeOnDelete(false);

        base.OnModelCreating(modelBuilder);
    }
}
