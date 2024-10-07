using System.ComponentModel.DataAnnotations;

namespace HotelAPI.DTOs.Requests;

public class GuestDTO
{
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(255, ErrorMessage = "First name cannot exceed 255 characters")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(255, ErrorMessage = "Last name cannot exceed 255 characters")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Identification number is required")]
    [MaxLength(20, ErrorMessage = "Identification number cannot exceed 20 characters")]
    public required string IdentificationNumber { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    public required string PhoneNumber { get; set; }
    
    public DateTime? Birthdate { get; set; }
}
