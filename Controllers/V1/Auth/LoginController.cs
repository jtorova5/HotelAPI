using HotelAPI.Config;
using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Controllers.V1.Auth;

[ApiController]
[Route("api/v1/login")]
public class LoginController(AppDbContext context, Utilities utilities) : ControllerBase
{
    private readonly AppDbContext _context = context;
    private readonly Utilities _utilities = utilities;
    [HttpPost("register")]
    public async Task<IActionResult> Register(Employee newUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (_context.Users.Any(u => u.Email == newUser.Email))
        {
            return BadRequest("Email already exists");
        }
        newUser.Password = _utilities.EncryptSHA256(newUser.Password);
        _context.Employees.Add(newUser);
        await _context.SaveChangesAsync();
        return Ok("Customer registered successfully");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await _context.Employees.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
        {
            return Unauthorized("Invalid email");
        }
        var passwordIsValid = user.Password == _utilities.EncryptSHA256(request.Password);
        if (passwordIsValid == false)
        {
            return Unauthorized("Invalid password");
        }
        var token = _utilities.GenerateJwtToken(user);
        return Ok(new
        {
            message = "Please, save this token: ",
            jwt = token
        });
    }
}
