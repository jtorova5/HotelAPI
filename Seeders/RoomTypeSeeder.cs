using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Seeders;

public class RoomTypeSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoomType>().HasData(
        new RoomType { Name = "Habitación simple", Description = "Una acogedora habitación básica con una cama individual, ideal para viajeros solos." },
        new RoomType { Name = "Habitación doble", Description = "Ofrece flexibilidad con dos camas individuales o una cama doble, perfecta para parejas o amigos." },
        new RoomType { Name = "Suite", Description = "Espaciosa y lujosa, con una cama king size y una sala de estar separada, ideal para quienes buscan confort y exclusividad." },
        new RoomType { Name = "Habitación Familiar", Description = "Diseñada para familias, con espacio adicional y varias camas para una estancia cómoda." }
        );
    }
}
