using Microsoft.AspNetCore.Mvc;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.Interfaces;
using AutoMapper;

namespace BloodDonationPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationRequestController : ControllerBase
    {
        private readonly IDonationRequestService _donationRequestService;

        public DonationRequestController(IDonationRequestService donationRequestService)
        {
            _donationRequestService = donationRequestService;
        }

        // GET: api/DonationRequest
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _donationRequestService.GetAllAsync();
            return Ok(requests);
        }

        // GET: api/DonationRequest/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _donationRequestService.GetByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        // POST: api/DonationRequest
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonationRequestDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _donationRequestService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/DonationRequest/status
        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateDonationRequestStatusDTO dto)
        {
            var updated = await _donationRequestService.UpdateStatusAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}
