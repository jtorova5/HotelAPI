using HotelAPI.Models;

namespace HotelAPI.Repositories;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllBookingsById(int userId);
    Task<Booking> GetBookingById(int id);
    Task AddBooking(Booking booking);
    Task DeleteBooking(int id);
}
