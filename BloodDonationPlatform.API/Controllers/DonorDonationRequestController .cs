using AutoMapper;
using BloodDonationPlatform.API.Exceptions;
using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;
using BloodDonationPlatform.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationPlatform.API.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class DonorDonationRequestController : ControllerBase
        {
            private readonly IDonorDonationRequestService _donorDonationRequestService;

        public DonorDonationRequestController(IDonorDonationRequestService donorDonationRequestService)
            {
                _donorDonationRequestService = donorDonationRequestService;
        }

            // GET: api/DonorDonationRequest
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var items = await _donorDonationRequestService.GetAllAsync();
                return Ok(items);
            }

       // GET: api/DonorDonationRequest/{id}
            [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _donorDonationRequestService.GetByIdAsync(id);
            if (item == null) throw new NotFoundExcptiondonorDonationRequest(id);
            return Ok(item);
        }

        // POST: api/DonorDonationRequest
        [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateDonorDonationRequestDTO dto)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var created = await _donorDonationRequestService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.DonorId }, created);
            }

            // PUT: api/DonorDonationRequest/status
            [HttpPut("status")]
            public async Task<IActionResult> UpdateStatus([FromBody] UpdateDonorDonationRequestStatusDTO dto)
            {
                var updated = await _donorDonationRequestService.UpdateStatusAsync(dto);
                if (!updated) return NotFound();
                return NoContent();
            }

            // GET: api/DonorDonationRequest/by-donor/{donorId}
            //[HttpGet("by-donor/{donorId}")]
            //public async Task<IActionResult> GetByDonorId(int donorId)
            //{
            //    var items = await _donorDonationRequestService.GetByDonorIdAsync(donorId);
            //    return Ok(items);
            //}
        }
}


