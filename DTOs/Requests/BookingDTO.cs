using System.ComponentModel.DataAnnotations;

namespace HotelAPI.DTOs.Requests;

public class BookingDTO
{
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Total cost must be provided")]
    public double TotalCost { get; set; }

    [Required(ErrorMessage = "Room id cost must be provided")]
    public int RoomId { get; set; }

    [Required(ErrorMessage = "Guest id cost must be provided")]
    public int GuestId { get; set; }

    [Required(ErrorMessage = "Employee id cost must be provided")]
    public int EmployeeId { get; set; }
}
