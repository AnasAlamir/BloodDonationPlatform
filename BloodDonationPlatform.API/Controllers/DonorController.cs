using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/donor")]
public class DonorController : ControllerBase
{
    private readonly IDonorService _donorService;

    public DonorController(IDonorService donorService)
    {
        _donorService = donorService;
    }
    [Authorize(Roles = "Donor")]
    [HttpGet]
    public async Task<IActionResult> GetDonorById()
    {
        var donorId = int.Parse(User.FindFirst("DonorId")!.Value);
        var donorDto = await _donorService.GetDonorByIdAsync(donorId);
        if (donorDto == null)
            return NotFound(new { Message = "Donor not found." });

        return Ok(donorDto);
    }
}
