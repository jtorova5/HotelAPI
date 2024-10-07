using HotelAPI.DTOs.Requests;
using HotelAPI.Models;
using HotelAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Bookings;

[ApiController]
[Route("api/c1/bookings")]
[Tags("Booking")]
public class BookingsCreateController : BookingsController
{
    public BookingsCreateController(IBookingRepository bookingRepository) : base(bookingRepository) { }

    // POST: api/v1/bookings
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddBooking([FromBody] BookingDTO bookingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var booking = new Booking
        {
            EndDate = bookingDto.EndDate,
            TotalCost = bookingDto.TotalCost,
            RoomId = bookingDto.RoomId,
            GuestId = bookingDto.GuestId,
            EmployeeId = bookingDto.EmployeeId,
            StartDate = DateTime.Now
        };

        try
        {
            await _bookingRepository.AddBooking(booking);
            return Ok(booking);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
