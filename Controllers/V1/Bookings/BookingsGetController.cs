using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers.V1.Bookings;

[ApiController]
[Route("api/v1/bookings")]
public class BookingsGetController : BookingsController
{
    public BookingsGetController(IBookingRepository bookingRepository) : base(bookingRepository) {}

    
}
