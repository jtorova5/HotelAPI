using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table("bookings")]
public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime EndDate { get; set; }

    [Column("total_cost")]
    public double TotalCost { get; set; }

    [Required]
    [ForeignKey("rooms")]
    public int RoomId { get; set; }

    [Required]
    [ForeignKey("guests")]
    public int GuestId { get; set; }

    [Required]
    [ForeignKey("employees")]
    public int EmployeeId { get; set; }

    public Booking(DateTime endDate, double totalCost, int roomId, int guestId, int employeeId)
    {
        StartDate = DateTime.Now;
        EndDate = endDate;
        TotalCost = totalCost;
        RoomId = roomId;
        GuestId = guestId;
        EmployeeId = employeeId;
    }

    public Booking()
    {

    }
}
