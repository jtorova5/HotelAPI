using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Rooms;

[ApiController]
[Route("api/v1/rooms")]
[Tags("Rooms")]
public class RoomsController : ControllerBase
{
    protected readonly IRoomRepository _roomRepository;

    public RoomsController(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
}
