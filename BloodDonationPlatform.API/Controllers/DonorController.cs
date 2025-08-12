using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        [HttpGet]
        public ActionResult AllProducts()
        {
            return Ok(_donorService.GetAll());
        }
    }
}
