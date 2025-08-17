using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypeController : ControllerBase
    {
        private readonly IBloodTypeService _bloodTypeService;

        public BloodTypeController(IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bloodTypes = await _bloodTypeService.GetAllAsync();
            return Ok(bloodTypes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bloodType = await _bloodTypeService.GetByIdAsync(id);
            return Ok(bloodType);
        }
    }
}
