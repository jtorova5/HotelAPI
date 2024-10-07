using HotelAPI.Models;
using HotelAPI.Seeders;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Guest> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomsTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        RoomSeeder.Seed(modelBuilder);
        RoomTypeSeeder.Seed(modelBuilder);
    }
}
