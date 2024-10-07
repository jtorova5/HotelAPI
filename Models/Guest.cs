using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table("guests")]
public class Guest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("first_name")]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("last_name")]
    public required string LastName { get; set; }

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    [Column("email")]
    public required string Email { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("identification_number")]
    public required string IdentificationNumber { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("phone_number")]
    public required string PhoneNumber { get; set; }

    [Column("birthdate")]
    public DateTime Birthdate { get; set; }

    public Guest(string firstName, string lastName, string email, string identificationNumber, string phoneNumber, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdentificationNumber = identificationNumber;
        PhoneNumber = phoneNumber;
        Birthdate = birthDate;
    }

        public Guest(string firstName, string lastName, string email, string identificationNumber, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdentificationNumber = identificationNumber;
        PhoneNumber = phoneNumber;
        Birthdate = DateTime.Now;
    }

    public Guest()
    {

    }
}
