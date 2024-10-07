using HotelAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Rooms;

[ApiController]
[Route("api/v1/rooms")]
[Tags("Rooms")]
public class RoomsGetController : RoomsController
{
    public RoomsGetController(IRoomRepository roomRepository) : base(roomRepository) { }

    // GET: api/v1/rooms
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllRooms()
    {
        try
        {
            var rooms = await _roomRepository.GetAllRooms();
            return Ok(rooms);
        }
        catch (InvalidOperationException)
        {
            return NotFound("No rooms found in the database.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/v1/rooms/available
    [HttpGet("available")]
    public async Task<IActionResult> GetAllAvailableRooms()
    {
        try
        {
            var availableRooms = await _roomRepository.GetAllAvailableRooms();
            return Ok(availableRooms);
        }
        catch (InvalidOperationException)
        {
            return NotFound("No available rooms found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/v1/rooms/occupied
    [HttpGet("occupied")]
    [Authorize]
    public async Task<IActionResult> GetAllUnavailableRooms()
    {
        try
        {
            var unavailableRooms = await _roomRepository.GetAllUnavailableRooms();
            return Ok(unavailableRooms);
        }
        catch (InvalidOperationException)
        {
            return NotFound("No unavailable rooms found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/v1/rooms/{id}
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetRoomById(int id)
    {
        try
        {
            var room = await _roomRepository.GetRoomById(id);
            return Ok(room);
        }
        catch (ArgumentNullException)
        {
            return NotFound($"Room with id {id} not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/v1/rooms/status
    [HttpGet("status")]
    public async Task<IActionResult> RoomsSummary()
    {
        try
        {
            var summary = await _roomRepository.RoomsSummary();
            return Ok(summary);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
