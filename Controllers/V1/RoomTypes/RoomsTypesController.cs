using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.RoomTypes;

[ApiController]
[Route("api/v1/room_types")]
public class RoomsTypesController : ControllerBase
{
    protected readonly IRoomTypeRepository _roomTypeRepository;

    public RoomsTypesController(IRoomTypeRepository roomTypeRepository)
    {
        _roomTypeRepository = roomTypeRepository;
    }
}
