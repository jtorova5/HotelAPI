using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table("employees")]
public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column ("first_name")]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    [Column ("last_name")]
    public required string LastName { get; set; }

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    [Column ("email")]
    public required string Email { get; set; }

    [Required]
    [MaxLength(20)]
    [Column ("identification_number")]
    public required string IdentificationNumber { get; set; }

    [Required]
    [MaxLength(255)]
    [Column ("password")]
    public required string Password { get; set; }

    public Employee(string firstName, string lastName, string email, string identificationNumber, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdentificationNumber = identificationNumber;
        Password = password;
    }

    public Employee()
    {

    }
}
