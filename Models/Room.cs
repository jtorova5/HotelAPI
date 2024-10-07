using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table("rooms")]
public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    [Column("room_number")]
    public string? RoomNumber { get; set; }

    [Required]
    [Column("price_per_night")]
    [Range(0.01, double.MaxValue)]
    public double PricePerNight { get; set; }

    [Required]
    [Column("availability")]
    public bool Availability { get; set; }

    [Required]
    [Column("max_occupancy_persons")]
    [Range(1, 10)]
    public byte MaxOccupancyPersons { get; set; }

    [Required]
    [Column("room_type_id")]
    [ForeignKey("RoomTypeId")]
    public int RoomTypeId { get; set; }

    public Room(string roomNumber, double pricePerNight, bool availability, byte maxOccupancyPersons, int roomTypeId)
    {
        RoomNumber = roomNumber.Trim();
        PricePerNight = pricePerNight;
        Availability = availability;
        MaxOccupancyPersons = maxOccupancyPersons;
        RoomTypeId = roomTypeId;
    }

    public Room()
    {
    }
}
