using CINEMA_System_APi.Models;
using Microsoft.EntityFrameworkCore;

namespace CINEMA_System_APi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Define your DbSets for your entities here
        // Example:
         public DbSet<Movie> Movies { get; set; }
         public DbSet<Booking> Bookings { get; set; }
         public DbSet<Gener> Geners { get; set; }
         public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gener>()
                .HasMany(Gener => Gener.Movies)
                .WithOne(Movie => Movie.Gener)
                .HasForeignKey(Movie => Movie.GenerId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Customer>()
                .HasMany(Gener => Gener.Bookings)
                .WithOne(Movie => Movie.Customer)
                .HasForeignKey(Movie => Movie.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Movie>()
               .HasMany(Gener => Gener.Bookings)
               .WithOne(Movie => Movie.Movie)
               .HasForeignKey(Movie => Movie.MovieId)
               .OnDelete(DeleteBehavior.NoAction);




            modelBuilder.Entity<Gener>().HasData(
                new Gener { id = 1, Name = "Action" },
                new Gener { id = 2, Name = "Sci-Fi" },
                new Gener { id = 3, Name = "Drama" },
                new Gener { id = 4, Name = "Comedy" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    id = 1,
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    Duration = 148,
                    ReleaseYear = 2010,
                    Rating = 8.8m,
                    TicketPrice = 150,
                    AvailableSeats = 50,
                    GenerId = 2 
                },
                new Movie
                {
                    id = 2,
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    Duration = 152,
                    ReleaseYear = 2008,
                    Rating = 9.0m,
                    TicketPrice = 140,
                    AvailableSeats = 30,
                    GenerId = 1 
                },
                new Movie
                {
                    id = 3,
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Duration = 142,
                    ReleaseYear = 1994,
                    Rating = 9.3m,
                    TicketPrice = 120,
                    AvailableSeats = 100,
                    GenerId = 3 
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "Mohamed Ateto",
                    Email = "mohamed.ateto@example.com",
                    PhoneNumber = "01012345678"
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Hassan Ali",
                    Email = "hassan.ali@example.com",
                    PhoneNumber = "01298765432"
                }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BookingDate = new DateTime(2026, 10, 15, 14, 30, 0, DateTimeKind.Utc),
                    NumberOfTickets = 2,
                    TotalPrice = 300, 
                    CustomerId = 1,   
                    MovieId = 1       
                },
                new Booking
                {
                    Id = 2,
                    BookingDate = new DateTime(2026, 10, 16, 18, 00, 0, DateTimeKind.Utc),
                    NumberOfTickets = 1,
                    TotalPrice = 140, 
                    CustomerId = 2,   
                    MovieId = 2       
                }
            );
        }
    }
}
