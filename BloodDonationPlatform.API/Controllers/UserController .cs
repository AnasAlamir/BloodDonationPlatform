using BloodDonationPlatform.API.Services.DTOs.User;
using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var result = await _userService.LoginAsync(dto.PhoneNumber, dto.Password);
            // Add claims from service result
            var claims = new List<Claim>
            {
                new Claim("PhoneNumber", result.PhoneNumber),
                new Claim(ClaimTypes.Role, result.Role.ToString()),
                new Claim("UserId", result.UserId.ToString())
            };
            if (result.HospitalId.HasValue)
            {
                claims.Add(new Claim("HospitalId", result.HospitalId.Value.ToString()));
            }
            else if (result.DonorId.HasValue)
            {
                claims.Add(new Claim("DonorId", result.DonorId.Value.ToString()));
            }
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Ok(new { message = "Login successful", result.UserId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { message = "Logged out successfully" });
    }
}
