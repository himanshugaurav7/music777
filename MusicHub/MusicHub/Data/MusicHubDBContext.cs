using Microsoft.EntityFrameworkCore;
using MusicHub.Model;

namespace MusicHub.Data
{
    public class MusicHubDBContext : DbContext
    {
        public MusicHubDBContext(DbContextOptions<MusicHubDBContext> options) : base(options)
        {
        }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<MusicCD> MusicCDs { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicCD>().HasData(
                new MusicCD
                {
                    Id = 1,
                    Title = "Album1",
                    Artist = "Artist A",
                    Genre = "Rock",
                    Price = 20,
                    StockQuantity = 100
                },
                new MusicCD
                {
                    Id = 2,
                    Title = "Ben Hits",
                    Artist = "Artist B",
                    Genre = "POP",
                    Price = 15,
                    StockQuantity = 75
                },
                new MusicCD
                {
                    Id = 3,
                    Title = "Jazz Fashion",
                    Artist = "Artist C",
                    Genre = "Jazz",
                    Price = 25,
                    StockQuantity = 50
                },
                new MusicCD
                {
                    Id = 4,
                    Title = "Classic Fusion",
                    Artist = "Artist D",
                    Genre = "Classical",
                    Price = 30,
                    StockQuantity = 120
                },
                new MusicCD
                {
                    Id = 5,
                    Title = "Electronic Beats",
                    Artist = "Artist E",
                    Genre = "Electronic",
                    Price = 18,
                    StockQuantity = 80
                }
            );
            modelBuilder.Entity<Order>().HasData
                (
                new Order
                {
                    Id = 1,
                    MusicCDId = 1,
                    UserId = 101,
                    Quantity = 2,
                    TotalPrice = 41,
                    OrderDate = DateTime.Parse("2024-03-05 10:30:00")
                },
                new Order
                {
                    Id = 2,
                    MusicCDId = 3,
                    UserId = 102,
                    Quantity = 1,
                    TotalPrice = 25,
                    OrderDate = DateTime.Parse("2024-03-05 11:30:00")
                },
                new Order
                {
                    Id = 3,
                    MusicCDId = 2,
                    UserId = 103,
                    Quantity = 3,
                    TotalPrice = 47,
                    OrderDate = DateTime.Parse("2024-03-05 14:20:00")
                },
                new Order
                {
                    Id = 4,
                    MusicCDId = 4,
                    UserId = 104,
                    Quantity = 1,
                    TotalPrice = 30,
                    OrderDate = DateTime.Parse("2024-02-05 15:55:00")
                },
                new Order
                {
                    Id = 5,
                    MusicCDId = 5,
                    UserId = 105,
                    Quantity = 2,
                    TotalPrice = 37,
                    OrderDate = DateTime.Parse("2024-03-05 17:10:00")
                }

                );
        }
    }
}
