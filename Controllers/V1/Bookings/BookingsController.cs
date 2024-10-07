using HotelAPI.DTOs.Requests;
using HotelAPI.Models;
using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Bookings;

[ApiController]
[Route("api/v1/bookings")]
public class BookingsController : ControllerBase
{
    protected readonly IBookingRepository _bookingRepository;

    public BookingsController(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
}
