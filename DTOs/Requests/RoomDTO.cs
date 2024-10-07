using System.ComponentModel.DataAnnotations;

namespace HotelAPI.DTOs.Requests;

public class RoomDTO
{
    [Required(ErrorMessage = "Room number is required")]
    [MaxLength(10, ErrorMessage = "Room number cannot exceed 10 characters")]
    public string? RoomNumber { get; set; }

    [Required(ErrorMessage = "Price per night is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price per night must be a positive number")]
    public double PricePerNight { get; set; }

    [Required(ErrorMessage = "Availability is required")]
    public bool Availability { get; set; }

    [Required(ErrorMessage = "Max occupancy persons is required")]
    [Range(1, 10, ErrorMessage = "Max occupancy persons must be between 1 and 10")]
    public byte MaxOccupancyPersons { get; set; }

    [Required(ErrorMessage = "Room type ID is required")]
    public int RoomTypeId { get; set; }
}
