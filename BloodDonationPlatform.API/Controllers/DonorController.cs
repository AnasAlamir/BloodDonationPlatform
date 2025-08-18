//using BloodDonationPlatform.API.Services.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace BloodDonationPlatform.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DonorController : ControllerBase
//    {
//        private readonly IDonorService _donorService;
//        public DonorController(IDonorService donorService)
//        {
//            _donorService = donorService;
//        }
//        [HttpGet]
//        public ActionResult AllProducts()
//        {
//            return Ok(_donorService.GetAll());
//        }
//    }
//}

using BloodDonationPlatform.API.Services.Interfaces;
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

    /// <summary>
    /// شاشة بيانات المتبرع
    /// </summary>
    [HttpGet("{donorId}")]
    public async Task<IActionResult> GetDonor(int donorId)
    {
        var donorDto = await _donorService.GetDonorByIdAsync(donorId);
        if (donorDto == null)
            return NotFound(new { Message = "Donor not found." });

        return Ok(donorDto);
    }

    /// <summary>
    /// شاشة الطلبات الموجهة للمتبرع
    /// </summary>
    [HttpGet("{donorId}/requests")]
    public async Task<IActionResult> GetRequests(int donorId)
    {
        var requests = await _donorService.GetRequestsForDonorAsync(donorId);
        return Ok(requests);
    }
}
