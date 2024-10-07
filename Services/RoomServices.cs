using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services;

public class RoomServices : IRoomRepository
{
    protected readonly AppDbContext _context;

    public RoomServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Room>> GetAllAvailableRooms()
    {
        try
        {
            var availableRooms = await _context.Rooms
                .Where(r => r.Availability)
                .ToListAsync();

            if (!availableRooms.Any())
            {
                throw new InvalidOperationException("No available rooms found");
            }
            return availableRooms;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving available rooms", ex);
        }
    }

    public async Task<IEnumerable<Room>> GetAllRooms()
    {
        if (!_context.Rooms.Any())
        {
            throw new InvalidOperationException("No rooms found in the database");
        }
        return await _context.Rooms.ToListAsync();
    }

    public async Task<IEnumerable<Room>> GetAllUnavailableRooms()
    {
        try
        {
            var unavailableRooms = await _context.Rooms
                .Where(r => !r.Availability)
                .ToListAsync();

            if (!unavailableRooms.Any())
            {
                throw new InvalidOperationException("No unavailable rooms found");
            }
            return unavailableRooms;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving unavailable rooms", ex);
        }
    }

    public async Task<Room> GetRoomById(int id)
    {
        try
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room), "Room not found");
            }

            return room;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving the room", ex);
        }
    }

    public async Task<dynamic> RoomsSummary()
    {
        try
        {
            var totalRooms = await _context.Rooms.CountAsync();
            var occupiedRooms = await _context.Rooms.CountAsync(r => r.Availability);
            var availableRooms = totalRooms - occupiedRooms;

            return new
            {
                OccupiedRooms = occupiedRooms,
                AvailableRooms = availableRooms
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving room summary", ex);
        }
    }
}
