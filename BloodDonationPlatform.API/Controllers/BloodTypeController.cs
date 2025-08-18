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
        public async Task<IActionResult> GetAllBloodTypes()
        {
            var bloodTypes = await _bloodTypeService.GetAllBloodTypesAsync();
            return Ok(bloodTypes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBloodTypeById(int id)
        {
            var bloodType = await _bloodTypeService.GetBloodTypeByIdAsync(id);
            return Ok(bloodType);
        }
    }
}
