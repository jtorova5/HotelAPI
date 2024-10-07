namespace HotelAPI.Models;

public class Booking
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double TotalCost { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
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
