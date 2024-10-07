using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Guests;

[ApiController]
[Route("api/v1/guests")]
[Tags("Guest")]
public class GuestsDeleteController : GuestsController
{
    public GuestsDeleteController(IGuestRepository guestRepository) : base(guestRepository) { }

    // DELETE: api/v1/guests/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGuest(int id)
    {
        try
        {
            await _guestRepository.DeleteGuest(id);
            return Ok("Guest deleted successfully");
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
}

