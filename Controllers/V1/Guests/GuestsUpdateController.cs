using HotelAPI.DTOs.Requests;
using HotelAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Guests;

[ApiController]
[Route("api/v1/guests")]
public class GuestsUpdateController : GuestsController
{
    public GuestsUpdateController(IGuestRepository guestRepository) : base(guestRepository) { }

    // PUT: api/v1/guests/{id}
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateGuest(int id, [FromBody] GuestDTO guestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingGuest = await _guestRepository.GetGuestById(id);
        if (existingGuest == null)
        {
            return NotFound($"Guest with id {id} not found.");
        }

        existingGuest.FirstName = guestDto.FirstName;
        existingGuest.LastName = guestDto.LastName;
        existingGuest.Email = guestDto.Email;
        existingGuest.IdentificationNumber = guestDto.IdentificationNumber;
        existingGuest.PhoneNumber = guestDto.PhoneNumber;
        existingGuest.Birthdate = guestDto.Birthdate;

        try
        {
            await _guestRepository.UpdateGuest(existingGuest);
            return Ok("Guest updated successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
