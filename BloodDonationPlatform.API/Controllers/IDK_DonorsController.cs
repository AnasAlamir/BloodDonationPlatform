///I dont know what this for


//using BloodDonationPlatform.API.Services.DTOs.Doner;
//using BloodDonationPlatform.API.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//[ApiController]
//[Route("api/[controller]")]
//public class DonorsController : ControllerBase
//{
//    private readonly IDonorService _donorService;

//    public DonorsController(IDonorService donorService)
//    {
//        _donorService = donorService;
//    }

//    [HttpGet("{donorId}")]
//    public async Task<IActionResult> GetProfile(int donorId)
//    {
//        return Ok(await _donorService.GetProfileAsync(donorId));
//    }

//    [HttpGet("request/{requestId}/eligible")]
//    public async Task<IActionResult> GetEligible(int requestId)
//    {
//        return Ok(await _donorService.GetEligibleDonorsForRequestAsync(requestId));
//    }

//    [HttpPost("respond")]
//    public async Task<IActionResult> Respond(DonorResponseDTO dto)
//    {
//        await _donorService.RespondToDonationRequestAsync(dto);
//        return Ok(new { message = "Response recorded successfully" });
//    }
//}
