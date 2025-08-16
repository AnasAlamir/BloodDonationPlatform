using BloodDonationPlatform.API.Exceptions;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BloodDonationPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hospitals = await _hospitalService.GetAllHospitalsAsync();
            return Ok(hospitals);
        }
        [HttpGet("get-all-by-name")]
        public async Task<IActionResult> GetAllWithName()
        {
            var hospitals = await _hospitalService.GetAllNameHospitalsAsync();
            return Ok(hospitals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hospital = await _hospitalService.GetHospitalByIdAsync(id);
            if (hospital == null)
                return NotFound($"Hospital with ID {id} not found.");

            return Ok(hospital);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHospitalDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _hospitalService.CreateHospitalAsync(dto);
            return Ok(created);
            //return CreatedAtAction(nameof(GetById), new { id = created.CreatedBy }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHospitalDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _hospitalService.UpdateHospitalAsync(id, dto);
            if (updated == null)
                throw new HospitalNotFoundExceptions(id);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _hospitalService.DeleteHospitalAsync(id);
            if (!success)
                throw new HospitalNotFoundExceptions(id);

            return NoContent();
        }
    }

}
