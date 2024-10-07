using System.ComponentModel.DataAnnotations;

namespace HotelAPI.DTOs.Requests;

public class RoomTypeDTO
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public required string Name { get; set; }

    [MaxLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
    public string? Description { get; set; }
}
