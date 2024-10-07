using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Seeders;

public class RoomSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>().HasData(
        new Room { RoomNumber = "1", RoomTypeId = 1, PricePerNight = 50, Availability = true, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "2", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "3", RoomTypeId = 3, PricePerNight = 150, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "4", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "5", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "6", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "7", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "8", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "9", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "10", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "11", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "12", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "13", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "14", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "15", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "16", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "17", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "18", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "19", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "20", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "21", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "22", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "23", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "24", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "25", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "26", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "27", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "28", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "29", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "30", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "31", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "32", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "33", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "34", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "35", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "36", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "37", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "38", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "39", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "40", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "41", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "42", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "43", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "44", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "45", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "46", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "47", RoomTypeId = 3, PricePerNight = 150, Availability = false, MaxOccupancyPersons = 2 },
        new Room { RoomNumber = "48", RoomTypeId = 4, PricePerNight = 200, Availability = true, MaxOccupancyPersons = 4 },
        new Room { RoomNumber = "49", RoomTypeId = 1, PricePerNight = 50, Availability = false, MaxOccupancyPersons = 1 },
        new Room { RoomNumber = "50", RoomTypeId = 2, PricePerNight = 80, Availability = true, MaxOccupancyPersons = 2 }
        );
    }
}
