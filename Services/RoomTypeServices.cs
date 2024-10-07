using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services;

public class RoomTypeServices : IRoomTypeRepository
{
    protected readonly AppDbContext _context;

    public RoomTypeServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RoomType>> GetAllTypeRooms()
    {
        if (!_context.RoomsTypes.Any())
        {
            throw new InvalidOperationException("No rooms found in the database");
        }
        return await _context.RoomsTypes.ToListAsync();
    }

    public async Task<RoomType> GetRoomTypeById(int id)
    {
        try
        {
            var roomType = await _context.RoomsTypes.FindAsync(id);
            if (roomType == null)
            {
                throw new ArgumentNullException(nameof(roomType), "Room type not found");
            }
            return roomType;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving the room type", ex);
        }
    }
}
