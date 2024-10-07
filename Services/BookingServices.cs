using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services;

public class BookingServices : IBookingRepository
{
    protected readonly AppDbContext _context;

    public BookingServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddBooking(Booking booking)
    {
        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking), "Booking cannot be null");
        }

        try
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add booking into the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error adding the booking", ex);
        }
    }

    public async Task DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);

        if (booking == null)
        {
            throw new ArgumentNullException(nameof(booking), "Booking not found");
        }
        else
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsById(int userId)
    {
        try
        {
            var bookings = await _context.Bookings
                .Where(b => b.GuestId == userId)
                .ToListAsync();

            return bookings;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving bookings for the user", ex);
        }
    }

    public async Task<Booking> GetBookingById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be a positive integer", nameof(id));
        }
        try
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking), "Booking not found");
            }
            return booking;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving the booking", ex);
        }
    }
}
