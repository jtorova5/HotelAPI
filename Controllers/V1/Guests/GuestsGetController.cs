using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Guests;

[ApiController]
[Route("api/v1/guests")]
public class GuestsGetController : GuestsController
{
    public GuestsGetController(IGuestRepository guestRepository) : base(guestRepository) { }

    // GET: api/v1/guests
    [HttpGet]
    public async Task<IActionResult> GetAllGuests()
    {
        try
        {
            var guests = await _guestRepository.GetAllGuests();
            return Ok(guests);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/v1/guests/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGuestById(int id)
    {
        try
        {
            var guest = await _guestRepository.GetGuestById(id);
            return Ok(guest);
        }
        catch (ArgumentNullException)
        {
            return NotFound($"Guest with id {id} not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/v1/guests/search/{keyword}
    [HttpGet("search/{keyword}")]
    public async Task<IActionResult> GetGuestByKeyword([FromQuery] string keyword)
    {
        try
        {
            var guests = await _guestRepository.GetGuestByKeyword(keyword);
            return Ok(guests);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
