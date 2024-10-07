using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.RoomTypes;

[ApiController]
[Route("api/v1/room_types")]
public class RoomTypesGetController : RoomsTypesController
{
    public RoomTypesGetController(IRoomTypeRepository roomTypeRepository) : base(roomTypeRepository) { }

    // GET: api/v1/room_types
    [HttpGet]
    public async Task<IActionResult> GetAllTypeRooms()
    {
        try
        {
            var roomTypes = await _roomTypeRepository.GetAllTypeRooms();
            return Ok(roomTypes);
        }
        catch (InvalidOperationException)
        {
            return NotFound("No room types found in the database.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/v1/room_types/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomTypeById(int id)
    {
        try
        {
            var roomType = await _roomTypeRepository.GetRoomTypeById(id);
            return Ok(roomType);
        }
        catch (ArgumentNullException)
        {
            return NotFound($"Room type with id {id} not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
