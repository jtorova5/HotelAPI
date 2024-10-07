using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Bookings;

[ApiController]
[Route("api/v1/bookings")]
public class BookingsGetController : BookingsController
{
    public BookingsGetController(IBookingRepository bookingRepository) : base(bookingRepository) { }

    // GET: api/v1/bookings/search/{identification_number}
    [HttpGet("search/{identification_number}")]
    public async Task<IActionResult> GetAllBookingsById(int identification_number)
    {
        try
        {
            var bookings = await _bookingRepository.GetAllBookingsById(identification_number);
            return Ok(bookings);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/v1/bookings/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(int id)
    {
        try
        {
            var booking = await _bookingRepository.GetBookingById(id);
            return Ok(booking);
        }
        catch (ArgumentNullException)
        {
            return NotFound($"Booking with id {id} not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
