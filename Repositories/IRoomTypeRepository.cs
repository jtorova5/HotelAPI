using HotelAPI.Models;

namespace HotelAPI.Repositories;

public interface IRoomTypeRepository
{
    Task<IEnumerable<RoomType>> GetAllTypeRooms();
    Task<RoomType> GetRoomTypeById(int id);
}
