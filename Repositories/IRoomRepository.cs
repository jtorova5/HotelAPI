using HotelAPI.Models;

namespace HotelAPI.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAllAvailableRooms();
    Task<dynamic> RoomsSummary();
    Task<IEnumerable<Room>> GetAllRooms();
    Task<Room> GetRoomById(int id);
    Task<IEnumerable<Room>> GetAllUnavailableRooms();
}
