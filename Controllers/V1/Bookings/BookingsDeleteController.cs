using HotelAPI.Models;
using HotelAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Bookings;

[ApiController]
[Route("api/v1/bookings")]
public class BookingsDeleteController : BookingsController
{
    public BookingsDeleteController(IBookingRepository bookingRepository) : base(bookingRepository) { }

    // DELETE: api/v1/bookings/{id}
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        try
        {
            await _bookingRepository.DeleteBooking(id);
            return Ok("Booking deleted successfully");
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
