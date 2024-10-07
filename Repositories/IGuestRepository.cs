using HotelAPI.Models;

namespace HotelAPI.Repositories;

public interface IGuestRepository
{
    Task AddGuest(Guest guest);
    Task<IEnumerable<Guest>> GetAllGuests();
    Task<Guest> GetGuestById(int id);
    Task DeleteGuest(int id);
    Task<IEnumerable<Guest>> GetGuestByKeyword(string keyword);
    Task UpdateGuest(Guest guest);
}
