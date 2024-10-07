using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services;

public class GuestServices : IGuestRepository
{
    protected readonly AppDbContext _context;

    public GuestServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddGuest(Guest guest)
    {
        if (guest == null)
        {
            throw new ArgumentNullException(nameof(guest), "Guest cannot be null");
        }

        try
        {
            await _context.Users.AddAsync(guest);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add guest into the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error adding the guest", ex);
        }
    }

    public async Task DeleteGuest(int id)
    {
        var guest = await _context.Users.FindAsync(id);

        if (guest == null)
        {
            throw new ArgumentNullException(nameof(guest), "Guest not found");
        }
        else
        {
            _context.Users.Remove(guest);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Guest>> GetAllGuests()
    {
        if (!_context.Users.Any())
        {
            throw new InvalidOperationException("No guests found in the database");
        }
        return await _context.Users.ToListAsync();
    }

    public async Task<Guest> GetGuestById(int id)
    {
        try
        {
            var guest = await _context.Users.FindAsync(id);

            if (guest == null)
            {
                throw new ArgumentNullException(nameof(guest), "Guest not found");
            }

            return guest;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving the guest", ex);
        }
    }

    public async Task<IEnumerable<Guest>> GetGuestByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return await GetAllGuests();
        }

        try
        {
            var guests = await _context.Users.Where(
                g => g.FirstName.Contains(keyword) ||
                g.LastName.Contains(keyword) ||
                g.Email.Contains(keyword) ||
                g.IdentificationNumber.Contains(keyword) ||
                g.PhoneNumber.Contains(keyword))
                .ToListAsync();

            if (!guests.Any())
            {
                throw new InvalidOperationException("No guests found matching the keyword");
            }

            return guests;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving guests by keyword", ex);
        }
    }

    public async Task UpdateGuest(Guest guest)
    {
        if (guest == null)
        {
            throw new ArgumentNullException(nameof(guest), "Guest cannot be null");
        }
        try
        {
            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to update guest in the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error updating the guest", ex);
        }
    }
}

