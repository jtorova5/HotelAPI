using HotelAPI.DTOs.Requests;
using HotelAPI.Models;
using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Guests;

[ApiController]
[Route("api/v1/guests")]
[Tags("Guest")]
public class GuestsCreateController : GuestsController
{
    public GuestsCreateController(IGuestRepository guestRepository) : base(guestRepository) { }

    // POST: api/v1/guests
    [HttpPost]
    public async Task<IActionResult> AddGuest([FromBody] GuestDTO guestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var guest = new Guest
        {
            FirstName = guestDto.FirstName,
            LastName = guestDto.LastName,
            Email = guestDto.Email,
            IdentificationNumber = guestDto.IdentificationNumber,
            PhoneNumber = guestDto.PhoneNumber,
            Birthdate = guestDto.Birthdate
        };

        try
        {
            await _guestRepository.AddGuest(guest);
            return Ok(guest);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
