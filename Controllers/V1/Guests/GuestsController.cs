using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Guests;

[ApiController]
[Route("api/v1/guests")]
public class GuestsController : ControllerBase
{
    protected readonly IGuestRepository _guestRepository;

    public GuestsController(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }
}
